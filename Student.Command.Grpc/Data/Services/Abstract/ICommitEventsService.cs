using Student.Command.Grpc.Models;

namespace Student.Command.Grpc.Data.Services.Abstract
{
    public interface ICommitEventsService
    {
        Task CommitNewEventsAsync<T>(Aggregate<T> model);
    }
}
