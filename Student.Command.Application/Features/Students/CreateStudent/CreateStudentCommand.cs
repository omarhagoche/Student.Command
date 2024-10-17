using MediatR;
using Student.Command.Domain.Commands;

namespace Student.Command.Application.Features.Students.CreateStudent
{
    public record CreateStudentCommand(string Name, string Phone, string Address, Guid UserId) : ICreateStudentCommand, IRequest;
}
