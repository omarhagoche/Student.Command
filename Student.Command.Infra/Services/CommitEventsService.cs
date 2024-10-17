using Student.Command.Application.Contracts.Repositories;
using Student.Command.Application.Contracts.Services;
using Student.Command.Domain.Entities;
using Student.Command.Domain.Models;

namespace Student.Command.Infra.Services
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
