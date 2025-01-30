using Bookify.Domain.Apartments;
using Bookify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bookify.Infrastructure.Repositories
{
    internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {


        public ApartmentRepository(ApplicationDbContext context, ILogger<Repository<Apartment>> logger) : base(context, logger)
        {

        }

        public async Task<IEnumerable<Apartment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await DbSet.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return [];
            }
        }


    }
}
