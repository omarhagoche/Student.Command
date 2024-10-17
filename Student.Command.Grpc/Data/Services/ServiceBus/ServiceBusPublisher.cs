using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using Student.Command.Grpc.Data.Repositories.Abstract;
using Student.Command.Grpc.Data.Services.Abstract;
using Student.Command.Grpc.Entities;
using Student.Command.Grpc.Models;
using System.Text;

namespace Student.Command.Grpc.Data.Services.ServiceBus
{
    public class ServiceBusPublisher(
        IServiceProvider serviceProvider,
        IConfiguration configuration,
        ServiceBusClient serviceBusClient) : IServiceBusPublisher
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private readonly ServiceBusSender _sender = serviceBusClient.CreateSender(queueOrTopicName: configuration["ServiceBus:Topic"]);

        private static readonly object _lockObject = new();

        public void StartPublish()
        {
            Task.Run(PublishNonPublishedMessages);
        }

        private void PublishNonPublishedMessages()
        {
            lock (_lockObject)
            {
                using var scope = _serviceProvider.CreateScope();

                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var messages = unitOfWork.OutboxMessages.GetAllAsync().GetAwaiter().GetResult();

                PublishAndRemoveMessagesAsync(messages, unitOfWork).GetAwaiter().GetResult();
            }
        }

        private async Task PublishAndRemoveMessagesAsync(IEnumerable<OutboxMessage> messages, IUnitOfWork unitOfWork)
        {
            foreach (var message in messages)
            {
                await SendMessageAsync(message.Event!);

                await unitOfWork.OutboxMessages.RemoveAsync(message);

                await unitOfWork.SaveChangesAsync();
            }

            await Task.CompletedTask;
        }

        private async Task SendMessageAsync(Event @event)
        {
            var body = new MessageBody(
                aggregateId: @event.AggregateId.ToString(),
                dateTime: @event.DateTime,
                sequence: @event.Sequence,
                type: @event.Type.ToString(),
                userId: @event.UserId.ToString(),
                version: @event.Version,
                data: ((dynamic)@event).Data
                );

            var messageBody = JsonConvert.SerializeObject(body);

            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody))
            {
                CorrelationId = @event.Id.ToString(),
                MessageId = @event.Id.ToString(),
                PartitionKey = @event.AggregateId.ToString(),
                SessionId = @event.AggregateId.ToString(),
                Subject = @event.Type.ToString(),
                ApplicationProperties = {
                    { nameof(@event.AggregateId), @event.AggregateId },
                    { nameof(@event.Sequence), @event.Sequence },
                    { nameof(@event.Version), @event.Version },
                }
            };

            await _sender.SendMessageAsync(message);
        }
    }
}
