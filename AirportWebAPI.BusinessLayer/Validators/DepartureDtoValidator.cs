using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Entities;
using FluentValidation;

namespace AirportWebAPI.BusinessLayer.Validators
{
    public class DepartureDtoValidator : AbstractValidator<DepartureDto>
    {
        public DepartureDtoValidator()
        {
            RuleFor(d => d.DepartureTime)
                .NotNull();

            RuleFor(d => d.Flight)
                .NotNull();

            RuleFor(d => d.Crew)
                .NotNull();

            RuleFor(d => d.Airplane)
                .NotNull();
        }
    }
}
