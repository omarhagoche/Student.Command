using Student.Command.Grpc.Commands;
using Student.Command.Grpc.Events;

namespace Student.Command.Grpc.Extensions
{
    public static class EventsExtensions
    {
        public static StudentCreated ToEvent(this CreateStudentCommand command)
            => new(
                Guid.NewGuid(),
                command.UserId,
                new Events.DataTypes.StudentCreatedData(
                    command.Name,
                    command.Phone,
                    command.Address));

        public static StudentUpdated ToEvent(this UpdateStudentCommand command, int sequence)
            => new(
                command.Id,
                command.UserId,
                sequence,
                new Events.DataTypes.StudentUpdatedData(
                    command.Name,
                    command.Phone,
                    command.Address));
    }
}
