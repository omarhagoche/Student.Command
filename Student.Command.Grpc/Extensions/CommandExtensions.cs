using Student.Command.Grpc.Commands;
using Student.Command.Grpc.Protos;

namespace Student.Command.Grpc.Extensions
{
    public static class CommandExtensions
    {
        public static CreateStudentCommand ToCommand(this CreateStudentRequest request)
            => new(
                request.Name,
                request.Phone,
                request.Address,
                Guid.Parse(request.UserId));

        public static UpdateStudentCommand ToCommand(this UpdateStudentRequest request)
            => new(
                Guid.Parse(request.Id),
                request.Name,
                request.Phone,
                request.Address,
                Guid.Parse(request.UserId));
    }
}
