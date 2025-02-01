using Bookify.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Apartments
{
    [ApiController]
    [Route("api/[controller]")]

    public class ApartmentsController : ControllerBase
    {
        private ISender Sender { get; }

        public ApartmentsController(ISender sender)
        {
            Sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> SearchApartments(
            DateOnly startDate,
            DateOnly endDate,
            CancellationToken cancellationToken)
        {
            var query = new SearchApartmentQuery(startDate, endDate);
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
