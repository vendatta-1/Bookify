using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings.GetBooking
{
    public record GetBookingQuery(Guid Id) : IQuery<BookingResponse>
    {

    }
}
