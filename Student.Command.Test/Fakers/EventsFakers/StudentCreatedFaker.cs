using Student.Command.Domain.Events;
using Student.Command.Domain.Events.DataTypes;

namespace Student.Command.Test.Fakers.EventsFakers
{
    public class StudentCreatedFaker : CustomConstructorFaker<StudentCreated>
    {
        public StudentCreatedFaker()
        {
            RuleFor(r => r.AggregateId, f => f.Random.Guid());
            RuleFor(r => r.Sequence, 1);
            RuleFor(r => r.UserId, f => f.Random.Guid());
            RuleFor(r => r.Version, 1);
            RuleFor(r => r.DateTime, DateTime.UtcNow);
            RuleFor(r => r.Data, f => new StudentCreatedDataFaker());
        }
    }
    public class StudentCreatedDataFaker : CustomConstructorFaker<StudentCreatedData>
    {
        public StudentCreatedDataFaker()
        {
            RuleFor(r => r.Name, f => f.Name.FullName());
            RuleFor(r => r.Address, f => f.Address.FullAddress());
            RuleFor(r => r.Phone, f => f.Phone.PhoneNumber());
        }
    }
}
