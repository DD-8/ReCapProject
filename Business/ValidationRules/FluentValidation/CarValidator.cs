using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.MotorPower).NotNull();
            RuleFor(c => c.Km).NotNull();
            RuleFor(c => c.Km).GreaterThanOrEqualTo(0);
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).NotNull();
            RuleFor(c => c.ModelYear).GreaterThan((short)1886).LessThan((short)(DateTime.Now.Year+1));
        }
    }
}
