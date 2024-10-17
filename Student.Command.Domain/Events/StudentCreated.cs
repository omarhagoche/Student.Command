using Student.Command.Domain.Entities;
using Student.Command.Domain.Events.DataTypes;

namespace Student.Command.Domain.Events
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
