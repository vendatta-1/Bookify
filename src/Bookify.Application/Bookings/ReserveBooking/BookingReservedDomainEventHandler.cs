using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBooking
{
    internal sealed class BookingReservedDomainEventHandler(
        IBookingRepository bookingRepository,
        IUserRepository userRepository,
        IEmailService emailService) :
        INotificationHandler<BookingReservedDomainEvent>
    {
        private readonly IBookingRepository _bookingRepository = bookingRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IEmailService _emailService = emailService;

        public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(notification.id, cancellationToken);

            if (booking == null)
            {
                return;
            }

            var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);

            if (user is null)
            {
                return;
            }

            await _emailService.SendEmailAsync(user.Email,
                "Booking is reserved!",
                "please confirm the booking within 10 minutes");

        }
    }
}
