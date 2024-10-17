using Student.Command.Domain.Enums;

namespace Student.Command.Domain.Events.DataTypes
{
    public record StudentCreatedData(string Name, string Phone, string Address) : IEventData
    {
        public EventType Type => EventType.StudentCreated;
    }
}
