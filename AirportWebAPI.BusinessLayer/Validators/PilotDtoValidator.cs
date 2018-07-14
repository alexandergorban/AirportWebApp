using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Models;
using FluentValidation;

namespace AirportWebAPI.BusinessLayer.Validators
{
    public class PilotDtoValidator : AbstractValidator<PilotDto>
    {
        public PilotDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1)
                .MaximumLength(20);

            RuleFor(p => p.Surname)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1)
                .MaximumLength(30);

            RuleFor(p => p.DateOfBirth)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now);

            RuleFor(p => p.Experience)
                .NotNull()
                .NotEmpty()
                .GreaterThan(TimeSpan.Zero);
        }
    }
}
