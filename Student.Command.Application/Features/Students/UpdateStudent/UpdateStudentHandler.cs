using MediatR;
using Student.Command.Application.Contracts.Repositories;
using Student.Command.Application.Contracts.Services;
using Student.Command.Domain.Exceptions;

namespace Student.Command.Application.Features.Students.UpdateStudent
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

            var student = Domain.Models.Student.LoadFromHistory(events);

            student.Update(command);

            await _commitEventsService.CommitNewEventsAsync(student);
        }
    }
}
