using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.Bookings.ReserveBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Bookings
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookingsController : ControllerBase
    {
        public BookingsController(ISender sender)
        {
            Sender = sender;
        }

        private ISender Sender { get; }

        [HttpGet]
        public async Task<IActionResult> GetBooking([FromQuery] Guid id)
        {
            var query = new GetBookingQuery(id);

            var result = await Sender.Send(query);

            return result.IsSuccess ? Ok(result) : NotFound(new { result.Error.Code, result.Error.Message });
        }

        [HttpPost]
        public async Task<IActionResult> ReserveBooking(ReserveBookingRequest request,
            CancellationToken cancellationToken)
        {
            var command = new ReserveBookingCommand(
                request.ApartmentId,
                request.UserId,
                request.StartDate,
                request.EndDate
            );

            var result = await Sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, result.Value);
        }
    }
}
