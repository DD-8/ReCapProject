using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FuelTypeValidator : AbstractValidator<FuelType>
    {
        public FuelTypeValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
