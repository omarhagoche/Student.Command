namespace Student.Command.Grpc.Data.Repositories.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }

        IOutboxMessageRepository OutboxMessages { get; }

        Task SaveChangesAsync();
    }
}
