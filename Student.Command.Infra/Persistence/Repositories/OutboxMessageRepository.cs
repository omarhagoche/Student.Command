using Microsoft.EntityFrameworkCore;
using Student.Command.Application.Contracts.Repositories;
using Student.Command.Domain.Entities;

namespace Student.Command.Infra.Persistence.Repositories
{
    public class OutboxMessageRepository(AppDbCon appDbContext) : AsyncRepository<OutboxMessage>(appDbContext), IOutboxMessageRepository
    {
        private readonly AppDbCon _appDbContext = appDbContext;

        public void Remove(OutboxMessage entity)
        {
            _appDbContext.OutboxMessages.Remove(entity);
        }

        public async override Task<IEnumerable<OutboxMessage>> GetAllAsync()
        {
            return await _appDbContext.OutboxMessages
                                      .Include(o => o.Event)
                                      .ToListAsync();
        }
    }
}
