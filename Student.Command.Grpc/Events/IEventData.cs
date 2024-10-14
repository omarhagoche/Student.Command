using Student.Command.Grpc.Enums;
using System.Text.Json.Serialization;

namespace Student.Command.Grpc.Events
{
    public interface IEventData
    {
        [JsonIgnore]
        EventType Type { get; }
    }
}
