using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bookify.Infrastructure.Repositories
{
    internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private static readonly BookingStatus[] ActiveBookingStatus =
        [
            BookingStatus.Reserved,
            BookingStatus.Confirmed,
            BookingStatus.Completed,
        ];
        public BookingRepository(ApplicationDbContext context, ILogger<Repository<Booking>> logger) : base(context, logger)
        {
        }



        public async Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default)
        {
            return await DbSet.AnyAsync(booking =>

                booking.ApartmentId == apartment.Id &&
                    booking.Duration.EndDate >= duration.StartDate &&
                    booking.Duration.StartDate <= duration.EndDate &&
                    ActiveBookingStatus.Contains(booking.Status)

            , cancellationToken);
        }
    }
}
