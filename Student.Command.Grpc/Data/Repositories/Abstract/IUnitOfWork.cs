namespace Student.Command.Grpc.Data.Repositories.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        Task SaveChangesAsync();
    }
}
