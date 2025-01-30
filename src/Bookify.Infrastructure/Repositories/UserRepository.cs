using Bookify.Domain.Users;
using Bookify.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Bookify.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger<Repository<User>> logger) : base(context, logger)
        {
        }


    }
}
