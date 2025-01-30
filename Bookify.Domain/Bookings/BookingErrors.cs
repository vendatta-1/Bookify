using Bookify.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                  "the booking is not confermid");

        public static Error AlreadyStarted = new
                    Error(BookingErrorType.AlreadtStarted.ToString(),
                          "the booking has already started");

    }
}
