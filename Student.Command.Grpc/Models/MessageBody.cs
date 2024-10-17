namespace Student.Command.Grpc.Models
{
    public class MessageBody
    {
        public MessageBody(
            string aggregateId,
            int sequence,
            string userId,
            string type,
            object data,
            DateTime dateTime,
            int version)
        {
            AggregateId = aggregateId;
            Sequence = sequence;
            UserId = userId;
            Type = type;
            Data = data;
            DateTime = dateTime;
            Version = version;
        }
        public string AggregateId { get; set; }
        public int Sequence { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public object Data { get; set; }
        public DateTime DateTime { get; set; }
        public int Version { get; set; }
    }
}
