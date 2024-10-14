namespace Student.Command.Grpc.Data.Repositories.Abstract
{
    public interface IAsyncRepository<TDomain> where TDomain : class
    {
        Task AddAsync(TDomain entity);
        Task AddRangeAsync(IEnumerable<TDomain> entities);
        Task RemoveAsync(TDomain entity);
        Task RemoveRangeAsync(IList<TDomain> entities);
        Task<TDomain?> FindAsync(Guid id, bool includeRelated = false);
        Task<IEnumerable<TDomain>> GetAllAsync();
    }
}
