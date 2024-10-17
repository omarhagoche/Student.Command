using Student.Command.Domain.Enums;
using System.Text.Json.Serialization;

namespace Student.Command.Domain.Events
{
    public interface IEventData
    {
        [JsonIgnore]
        EventType Type { get; }
    }
}
