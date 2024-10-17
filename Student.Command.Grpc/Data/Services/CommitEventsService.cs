using Student.Command.Grpc.Data.Repositories.Abstract;
using Student.Command.Grpc.Data.Services.Abstract;
using Student.Command.Grpc.Entities;
using Student.Command.Grpc.Models;

namespace Student.Command.Grpc.Data.Services
{
    public class CommitEventsService(IUnitOfWork unitOfWork, IServiceBusPublisher serviceBusPublisher) : ICommitEventsService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IServiceBusPublisher _serviceBusPublisher = serviceBusPublisher;

        public async Task CommitNewEventsAsync<T>(Aggregate<T> model)
        {
            var newEvents = model.GetUncommittedEvents();

            await _unitOfWork.Events.AddRangeAsync(newEvents);

            var outboxMessages = OutboxMessage.ToManyMessages(newEvents);

            await _unitOfWork.OutboxMessages.AddRangeAsync(outboxMessages);

            await _unitOfWork.SaveChangesAsync();

            model.MarkChangesAsCommitted();

            _serviceBusPublisher.StartPublish();
        }
    }
}
