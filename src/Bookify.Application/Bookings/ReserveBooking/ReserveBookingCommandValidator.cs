﻿using FluentValidation;

namespace Bookify.Application.Bookings.ReserveBooking
{
    public class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
    {
        public ReserveBookingCommandValidator()
        {
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate);

            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.ApartmentId).NotEmpty();

        }
    }
}
