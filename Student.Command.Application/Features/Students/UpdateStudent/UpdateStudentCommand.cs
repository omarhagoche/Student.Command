using MediatR;
using Student.Command.Domain.Commands;

namespace Student.Command.Application.Features.Students.UpdateStudent
{
    public record UpdateStudentCommand(Guid Id, string Name, string Phone, string Address, Guid UserId) : IUpdateStudentCommand, IRequest;
}
