using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Models;
using FluentValidation;

namespace AirportWebAPI.BusinessLayer.Validators
{
    public class AirplaneDtoValidator : AbstractValidator<AirplaneDto>
    {
        public AirplaneDtoValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(10);

            RuleFor(a => a.DateOfIssue)
                .NotNull()
                .LessThan(DateTime.Now);

            RuleFor(a => a.LifeTime)
                .NotNull()
                .GreaterThan(TimeSpan.Zero);

            RuleFor(a => a.AirplaneType)
                .NotNull();
        }
    }
}
