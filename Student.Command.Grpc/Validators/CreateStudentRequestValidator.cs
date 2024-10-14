using FluentValidation;
using Student.Command.Grpc.Protos;

namespace Student.Command.Grpc.Validators
{
    public class CreateStudentRequestValidator : AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentRequestValidator()
        {
            RuleFor(r => r.Name)
                .Length(2, 20);

            RuleFor(r => r.Phone)
                .Length(9, 13);

            RuleFor(r => r.Address)
                .Length(2, 40);
        }
    }
}
