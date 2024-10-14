using MediatR;
using Student.Command.Grpc.Commands;
using Student.Command.Grpc.Data.Services.Abstract;

namespace Student.Command.Grpc.Handlers
{
    public class CreateStudentHandler(ICommitEventsService commitEventsService) : IRequestHandler<CreateStudentCommand>
    {
        private readonly ICommitEventsService _commitEventsService = commitEventsService;

        public async Task Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = Models.Student.Create(command);

            await _commitEventsService.CommitNewEventsAsync(student);
        }
    }
}
