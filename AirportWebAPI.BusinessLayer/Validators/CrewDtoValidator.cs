using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Entities;
using FluentValidation;

namespace AirportWebAPI.BusinessLayer.Validators
{
    public class CrewDtoValidator : AbstractValidator<CrewDto>
    {
        public CrewDtoValidator()
        {
            RuleFor(c => c.Pilot)
                .NotNull();

            RuleFor(c => c.Stewardesses)
                .NotNull();
        }
    }
}
