namespace Bookify.Domain.Bookings
{
    public enum BookingErrorType
    {
        NotFound = 1,
        Overlap,
        NotReserved,
        NotConfirmed,
        AlreadyStarted

    }
}
