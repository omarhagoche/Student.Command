using Microsoft.EntityFrameworkCore;
using Student.Command.Grpc.Data.Repositories.Abstract;
using Student.Command.Grpc.Entities;

namespace Student.Command.Grpc.Data.Repositories
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
