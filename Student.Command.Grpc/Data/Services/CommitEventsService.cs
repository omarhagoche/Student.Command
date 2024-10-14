using Student.Command.Grpc.Data.Repositories.Abstract;
using Student.Command.Grpc.Data.Services.Abstract;
using Student.Command.Grpc.Models;

namespace Student.Command.Grpc.Data.Services
{
    public class CommitEventsService(IUnitOfWork unitOfWork) : ICommitEventsService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task CommitNewEventsAsync<T>(Aggregate<T> model)
        {
            var newEvents = model.GetUncommittedEvents();

            await _unitOfWork.Events.AddRangeAsync(newEvents);

            await _unitOfWork.SaveChangesAsync();

            model.MarkChangesAsCommitted();
        }
    }
}
