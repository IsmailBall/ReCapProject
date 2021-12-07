using FluentValidation;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(200);
            RuleFor(c => c.ModelYear).Must(GreaterThanTwoWhousend);
        }

        private bool GreaterThanTwoWhousend(DateTime arg)
        {
            return arg.Year > 2000;
        }
    }
}
