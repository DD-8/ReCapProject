using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(c => c.BrandId).NotNull();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
