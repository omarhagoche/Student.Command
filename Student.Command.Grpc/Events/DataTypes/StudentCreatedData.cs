using Student.Command.Grpc.Enums;

namespace Student.Command.Grpc.Events.DataTypes
{
    public record StudentCreatedData(string Name, string Phone, string Address) : IEventData
    {
        public EventType Type => EventType.StudentCreated;
    }
}
