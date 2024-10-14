using Student.Command.Grpc.Enums;
using Student.Command.Grpc.Events;

namespace Student.Command.Grpc.Entities
{
    public abstract class Event
    {
        public long Id { get; set; }
        public Guid AggregateId { get; protected set; }
        public Guid UserId { get; protected set; }
        public EventType Type { get; protected set; }
        public int Sequence { get; protected set; }
        public DateTime DateTime { get; protected set; }
        public int Version { get; protected set; }
    }
    public abstract class Event<TData> : Event where TData : IEventData
    {
        public TData Data { get; protected set; }
        protected Event(
            Guid aggregateId,
            Guid userId,
            int sequence,
            TData data,
            int version = 1
            )
        {
            AggregateId = aggregateId;
            Sequence = sequence;
            UserId = userId;
            Type = data.Type;
            Data = data;
            Version = version;
            AggregateId = aggregateId;
            DateTime = DateTime.UtcNow;
        }
        protected Event(
            Guid aggregateId,
            Guid userId,
            int sequence,
            TData data,
            DateTime dateTime,
            int version = 1
            )
        {
            AggregateId = aggregateId;
            UserId = userId;
            Sequence = sequence;
            Type = data.Type;
            Data = data;
            DateTime = dateTime;
            Version = version;
            AggregateId = aggregateId;
        }


    }
}
