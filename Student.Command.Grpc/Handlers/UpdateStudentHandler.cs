using MediatR;
using Student.Command.Grpc.Commands;
using Student.Command.Grpc.Data.Repositories.Abstract;
using Student.Command.Grpc.Data.Services.Abstract;
using Student.Command.Grpc.Exceptions;

namespace Student.Command.Grpc.Handlers
{
    public class UpdateStudentHandler(IUnitOfWork unitOfWork, ICommitEventsService commitEventsService) : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICommitEventsService _commitEventsService = commitEventsService;

        public async Task Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllByAggregateIdAsync(command.Id, cancellationToken);

            if (!events.Any())
                throw new StudentNotFoundException();

            var student = Models.Student.LoadFromHistory(events);

            student.Update(command);

            await _commitEventsService.CommitNewEventsAsync(student);
        }
    }
}
