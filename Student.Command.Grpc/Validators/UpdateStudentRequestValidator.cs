using FluentValidation;
using Student.Command.Grpc.Protos;

namespace Student.Command.Grpc.Validators
{
    public class UpdateStudentRequestValidator : AbstractValidator<UpdateStudentRequest>
    {
        public UpdateStudentRequestValidator()
        {
            RuleFor(r => r.Id)
                .Must(id => Guid.TryParse(id, out var _))
                .NotEqual(Guid.Empty.ToString());

            RuleFor(r => r.Name)
              .Length(2, 20);

            RuleFor(r => r.Phone)
                .Length(9, 13);

            RuleFor(r => r.Address)
                .Length(2, 40);
        }
    }
}
