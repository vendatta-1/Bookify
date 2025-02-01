
using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using Dapper;

namespace Bookify.Application.Apartments.SearchApartments
{
    public sealed class
        SearchApartmentQueryHandler : IQueryHandler<SearchApartmentQuery, IReadOnlyList<ApartmentResponse>>
    {
        private static readonly int[] ActiveBookingStatuses =
        [
            (int)BookingStatus.Reserved,
            (int)BookingStatus.Confirmed,
            (int)BookingStatus.Completed
        ];

        private readonly ISqlConnectionFactory _connectionFactory;

        public SearchApartmentQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(SearchApartmentQuery request,
            CancellationToken cancellationToken)
        {
            if (request.StartDate > request.EndDate)
            {
                return new List<ApartmentResponse>();
            }

            using var connection = _connectionFactory.CreateConnection();

            const string sql = $"""
                               SELECT
                                   a.id AS Id,
                                   a.name AS Name,
                                   a.description AS Description,
                                   a.price_amount AS Price,
                                   a.price_currency AS Currency,
                                   a.address_country AS Country,
                                   a.address_state AS State,
                                   a.address_zip_code AS ZipCode,
                                   a.address_city AS City,
                                   a.address_street AS Street
                               FROM apartments AS a
                               WHERE NOT EXISTS
                               (
                                   SELECT 1
                                   FROM bookings AS b
                                   WHERE
                                       b.apartment_id = a.id AND
                                       b.duration_start_date <= CAST( @EndDate as date )  AND
                                       b.duration_end_date >=CAST( @StartDate AS DATE) AND
                                       b.status = ANY
                                       (@ActiveBookingStatuses)
                               )
                               """;
            var endDate = request.EndDate.ToDateTime(TimeOnly.MinValue);
            var startDate = request.StartDate.ToDateTime(TimeOnly.MinValue);
            var apartment = await connection.QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(sql, (
                (response, addressResponse) =>
                {
                    //this anonymous used to map projection between diff 
                    response.Address = addressResponse;
                    return response;
                }), new
                {
                    startDate,
                    endDate,
                    ActiveBookingStatuses
                }, splitOn: "Country");

            return apartment.ToList();
        }


    }
}
