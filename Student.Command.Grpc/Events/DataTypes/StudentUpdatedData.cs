using Student.Command.Grpc.Enums;

namespace Student.Command.Grpc.Events.DataTypes
{
    public record StudentUpdatedData(string Name, string Phone, string Address) : IEventData
    {
        public EventType Type => EventType.StudentUpdated;
    }
}
