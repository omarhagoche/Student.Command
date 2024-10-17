using Student.Command.Grpc.Entities;

namespace Student.Command.Grpc.Data.Repositories.Abstract
{
    public interface IOutboxMessageRepository : IAsyncRepository<OutboxMessage>
    {
        public void Remove(OutboxMessage entity);
    }
}
