using Student.Command.Domain.Entities;

namespace Student.Command.Application.Contracts.Repositories
{
    public interface IOutboxMessageRepository : IAsyncRepository<OutboxMessage>
    {
        public void Remove(OutboxMessage entity);
    }
}
