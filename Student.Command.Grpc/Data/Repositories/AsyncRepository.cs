using Microsoft.EntityFrameworkCore;
using Student.Command.Grpc.Data.Repositories.Abstract;

namespace Student.Command.Grpc.Data.Repositories
{
    public class AsyncRepository<TDomain>(AppDbCon appDbContext) : IAsyncRepository<TDomain> where TDomain : class
    {
        private readonly AppDbCon _appDbContext = appDbContext;

        public virtual async Task AddAsync(TDomain entity)
        {
            await _appDbContext.Set<TDomain>().AddAsync(entity);
        }



        public virtual async Task AddRangeAsync(IEnumerable<TDomain> entities)
        {
            await _appDbContext.Set<TDomain>().AddRangeAsync(entities);
        }

        public virtual async Task<TDomain?> FindAsync(Guid id, bool includeRelated = false)
        {
            return await _appDbContext.Set<TDomain>().FindAsync(id);
        }


        public virtual async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            return await _appDbContext.Set<TDomain>().AsNoTracking()
                                                .ToListAsync();
        }

        public virtual async Task RemoveAsync(TDomain entity)
        {
            await Task.CompletedTask;

            _appDbContext.Set<TDomain>().Remove(entity);
        }

        public virtual async Task RemoveRangeAsync(IList<TDomain> entities)
        {
            await Task.CompletedTask;

            _appDbContext.Set<TDomain>().RemoveRange(entities);
        }


    }
}
