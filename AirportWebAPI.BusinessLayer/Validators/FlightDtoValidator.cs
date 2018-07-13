using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Models;
using FluentValidation;

namespace AirportWebAPI.BusinessLayer.Validators
{
    class FlightDtoValidator : AbstractValidator<FlightDto>
    {
        public FlightDtoValidator()
        {
            RuleFor(f => f.FlightNumber)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1)
                .MaximumLength(10);

            RuleFor(f => f.DeparturePoint)
                .NotNull();

            RuleFor(f => f.DestinationPoint)
                .NotNull();

            RuleFor(f => f.DepartureTime)
                .NotNull();

            RuleFor(f => f.ArrivalTime)
                .NotNull();

        }
    }
}
