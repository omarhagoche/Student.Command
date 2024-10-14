using Grpc.Core;
using Student.Command.Grpc.Commands;
using Student.Command.Grpc.Events;
using Student.Command.Grpc.Extensions;

namespace Student.Command.Grpc.Models
{
    public class Student : Aggregate<Student>
    {
        private Student() { }
        public string Name { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;


        public static Student Create(CreateStudentCommand command)
        {
            var student = new Student();

            var @event = command.ToEvent();

            student.ApplyChange(@event);

            return student;
        }

        public void Apply(StudentCreated @event)
        {
            Name = @event.Data.Name;
            Phone = @event.Data.Phone;
            Address = @event.Data.Address;
        }

        public void Update(UpdateStudentCommand command)
        {
            if (Name == command.Name && Phone == command.Phone && Address == command.Address)
                throw new RpcException(new Status(StatusCode.FailedPrecondition, "Update faild"));

            var @event = command.ToEvent(Sequence + 1);

            ApplyChange(@event);
        }

        public void Apply(StudentUpdated @event)
        {
            Name = @event.Data.Name;
            Phone = @event.Data.Phone;
            Address = @event.Data.Address;
        }
    }
}
