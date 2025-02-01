using Bookify.Domain.Validation;

namespace Bookify.Domain.Bookings
{
    public static class BookingErrors
    {
        public static Error NotFound = new
            Error(ErrorCode.NotFound.ToString(),
            "The current booking is overlapping with an existing one.");

        public static Error NotReserved = new
            Error(BookingErrorType.NotReserved.ToString(),
                  "the booking is not pending");

        public static Error NotConfirmed = new
            Error(BookingErrorType.NotConfirmed.ToString(),
                  "the booking is not confirmed");

        public static Error AlreadyStarted = new
                    Error(BookingErrorType.AlreadyStarted.ToString(),
                          "the booking has already started");

        public static Error Overlap =
            new Error(BookingErrorType.Overlap.ToString(),
                "there is an Overlap occurred while try to book this Apartment");

    }
}
