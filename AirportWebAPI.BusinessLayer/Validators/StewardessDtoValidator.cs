using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Models;
using FluentValidation;

namespace AirportWebAPI.BusinessLayer.Validators
{
    class StewardessDtoValidator : AbstractValidator<StewardessDto>
    {
        public StewardessDtoValidator()
        {
            RuleFor(s => s.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1)
                .MaximumLength(20);

            RuleFor(s => s.Surname)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1)
                .MaximumLength(30);

            RuleFor(p => p.DateOfBirth)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now);
        }
    }
}
