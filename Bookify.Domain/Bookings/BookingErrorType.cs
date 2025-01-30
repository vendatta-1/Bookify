using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Bookings
{
    public enum BookingErrorType
    {
        NotFound = 1,
        Overlap ,
        NotReserved ,
        NotConfirmed ,
        AlreadtStarted

    }
}
