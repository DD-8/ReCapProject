using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TransmissionTypeValidator : AbstractValidator<TransmissionType>
    {
        public TransmissionTypeValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
        }
    }
}
