namespace Student.Command.Grpc.Entities
{
    public class OutboxMessage
    {
        public OutboxMessage(Event @event)
        {
            Event = @event;
        }

        private OutboxMessage(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
        public Event? Event { get; private set; }
        public static IEnumerable<OutboxMessage> ToManyMessages(IEnumerable<Event> events)
           => events.Select(e => new OutboxMessage(e));
    }
}
