using Student.Command.Grpc.Entities;

namespace Student.Command.Grpc.Data.Repositories.Abstract
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<IEnumerable<Event>> GetAllByAggregateIdAsync(Guid aggregateId, CancellationToken cancellationToken);
        Task<IEnumerable<Event>> GetAsPaginationAsync(int currentPage = 1, int pageSize = 100);
    }
}
