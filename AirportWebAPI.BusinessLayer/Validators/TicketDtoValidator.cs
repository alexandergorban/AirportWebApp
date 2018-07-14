using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Models;
using FluentValidation;

namespace AirportWebAPI.BusinessLayer.Validators
{
    public class TicketDtoValidator : AbstractValidator<TicketDto>
    {
        public TicketDtoValidator()
        {
            RuleFor(t => t.Number)
                .NotNull()
                .NotEmpty();

            RuleFor(t => t.Price)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
