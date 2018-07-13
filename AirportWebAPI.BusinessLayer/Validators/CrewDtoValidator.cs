using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Models;
using FluentValidation;

namespace AirportWebAPI.BusinessLayer.Validators
{
    class CrewDtoValidator : AbstractValidator<CrewDto>
    {
        public CrewDtoValidator()
        {
            RuleFor(c => c.Pilot)
                .NotNull();

            RuleFor(c => c.Stewardesseses)
                .NotNull();
        }
    }
}
