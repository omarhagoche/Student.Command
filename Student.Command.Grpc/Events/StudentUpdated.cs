using Student.Command.Grpc.Entities;
using Student.Command.Grpc.Events.DataTypes;

namespace Student.Command.Grpc.Events
{
    public class StudentUpdated(
        Guid aggregateId,
        Guid userId,
        int sequence,
        StudentUpdatedData data,
        int version = 1) : Event<StudentUpdatedData>(aggregateId, userId, sequence, data, version)
    {
    }
}
