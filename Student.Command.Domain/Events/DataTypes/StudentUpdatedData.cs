using Student.Command.Domain.Enums;

namespace Student.Command.Domain.Events.DataTypes
{
    public record StudentUpdatedData(string Name, string Phone, string Address) : IEventData
    {
        public EventType Type => EventType.StudentUpdated;
    }
}
