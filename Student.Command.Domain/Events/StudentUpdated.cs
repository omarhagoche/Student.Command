using Student.Command.Domain.Entities;
using Student.Command.Domain.Events.DataTypes;

namespace Student.Command.Domain.Events
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
