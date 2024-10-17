using Microsoft.EntityFrameworkCore;
using Student.Command.Application.Contracts.Repositories;
using Student.Command.Domain.Entities;

namespace Student.Command.Infra.Persistence.Repositories
{
    public class EventRepository : AsyncRepository<Event>, IEventRepository
    {
        private readonly AppDbCon _appDbContext;
        public EventRepository(AppDbCon appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Event>> GetAllByAggregateIdAsync(Guid aggregateId, CancellationToken cancellationToken)
            => await _appDbContext.Events
                                  .AsNoTracking()
                                  .Where(e => e.AggregateId == aggregateId)
                                  .OrderBy(e => e.Sequence)
                                  .ToListAsync(cancellationToken);



        public async Task<IEnumerable<Event>> GetAsPaginationAsync(int currentPage = 1, int pageSize = 2)
        {
            var skip = (currentPage - 1) * pageSize;

            return await _appDbContext.Events
                                      .AsNoTracking()
                                      .OrderBy(e => e.AggregateId)
                                      .ThenBy(e => e.Sequence)
                                      .Skip(skip)
                                      .Take(pageSize)
                                      .ToListAsync();
        }
    }
}
