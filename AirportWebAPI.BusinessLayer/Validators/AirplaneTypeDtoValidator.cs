using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Entities;
using FluentValidation;

namespace AirportWebAPI.BusinessLayer.Validators
{
    public class AirplaneTypeDtoValidator : AbstractValidator<AirplaneTypeDto>
    {
        public AirplaneTypeDtoValidator()
        {
            RuleFor(a => a.Model)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(30);

            RuleFor(a => a.NumberOfSeats)
                .NotNull()
                .GreaterThan(1)
                .LessThan(1000);

            RuleFor(a => a.LoadCapacity)
                .NotNull()
                .GreaterThan(1)
                .LessThan(1000000);
        }
    }
}
