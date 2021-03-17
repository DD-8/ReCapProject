using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BodyTypeValidator : AbstractValidator<BodyType>
    {
        public BodyTypeValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
