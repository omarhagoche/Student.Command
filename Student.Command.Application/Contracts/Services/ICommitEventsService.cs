using Student.Command.Domain.Models;

namespace Student.Command.Application.Contracts.Services
{
    public interface ICommitEventsService
    {
        Task CommitNewEventsAsync<T>(Aggregate<T> model);
    }
}
