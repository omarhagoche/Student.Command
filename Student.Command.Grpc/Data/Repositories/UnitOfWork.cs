using Student.Command.Grpc.Data.Repositories.Abstract;

namespace Student.Command.Grpc.Data.Repositories
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

        public async Task SaveChangesAsync() => await _appDbContext.SaveChangesAsync();
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
