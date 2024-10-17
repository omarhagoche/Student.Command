using Student.Command.Application.Contracts.Repositories;

namespace Student.Command.Infra.Persistence.Repositories
{
    public class UnitOfWork(AppDbCon appDbContext) : IUnitOfWork
    {
        private readonly AppDbCon _appDbContext = appDbContext;

        private IEventRepository? _events;
        public IEventRepository Events
        {
            get
            {
                if (_events != null)
                    return _events;

                return _events = new EventRepository(_appDbContext);
            }
        }
        private IOutboxMessageRepository? _outboxMessages;

        public IOutboxMessageRepository OutboxMessages
        {
            get
            {
                if (_outboxMessages != null)
                    return _outboxMessages;

                return _outboxMessages = new OutboxMessageRepository(_appDbContext);
            }
        }

        public async Task SaveChangesAsync() => await _appDbContext.SaveChangesAsync();
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
