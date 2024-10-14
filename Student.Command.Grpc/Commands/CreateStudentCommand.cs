using MediatR;

namespace Student.Command.Grpc.Commands
{
    public record CreateStudentCommand(string Name, string Phone, string Address, Guid UserId) : IRequest;
}
