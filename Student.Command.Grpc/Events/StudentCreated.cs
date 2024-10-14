using Student.Command.Grpc.Entities;
using Student.Command.Grpc.Events.DataTypes;

namespace Student.Command.Grpc.Events
{
    public class StudentCreated(
        Guid aggregateId,
        Guid userId,
        StudentCreatedData data,
        int sequence = 1,
        int version = 1) : Event<StudentCreatedData>(aggregateId, userId, sequence, data, version)
    {
    }
}
