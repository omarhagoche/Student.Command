namespace Student.Command.Application.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }

        IOutboxMessageRepository OutboxMessages { get; }

        Task SaveChangesAsync();
    }
}
