using MediatR;

namespace Student.Command.Grpc.Commands
{
    public record UpdateStudentCommand(Guid Id, string Name, string Phone, string Address, Guid UserId) : IRequest;
}
