 namespace Bookify.Domain.Bookings
{
    public record DateRange
    {
        private DateRange()
        {
        }

        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
        public int LengthIndDays => EndDate.DayNumber - StartDate.DayNumber;

        public static DateRange Create(DateOnly startDate, DateOnly endDate)
        {
            if (startDate > endDate)
            {
                throw new ApplicationException("End date precedes start date ");
            }

            return new DateRange()
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }
    }
}