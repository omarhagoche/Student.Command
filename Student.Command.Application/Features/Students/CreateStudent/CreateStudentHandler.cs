using MediatR;
using Student.Command.Application.Contracts.Services;

namespace Student.Command.Application.Features.Students.CreateStudent
{
    public class CreateStudentHandler(ICommitEventsService commitEventsService) : IRequestHandler<CreateStudentCommand>
    {
        private readonly ICommitEventsService _commitEventsService = commitEventsService;

        public async Task Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = Domain.Models.Student.Create(command);

            await _commitEventsService.CommitNewEventsAsync(student);
        }
    }
}
