using Bookify.Domain.Abstractions;
using Bookify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bookify.Infrastructure.Repositories
{
    internal abstract class Repository<T>
    where T : Entity
    {
        protected readonly ApplicationDbContext DbContext;

        protected readonly ILogger<Repository<T>> Logger;
        protected readonly DbSet<T> DbSet;
        protected Repository(ApplicationDbContext context, ILogger<Repository<T>> logger)
        {
            this.DbContext = context;
            Logger = logger;
            DbSet = DbContext.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            try
            {
                var entity = await DbSet.FirstOrDefaultAsync(u => u.Id == id, token);
                if (entity == null)
                {
                    Logger.LogInformation($"there is non entity has this id( {id} )in the database");
                }
                Logger.LogInformation($"returned successfully entity with id {id}");
                return entity;
            }
            catch (Exception e)
            {
                Logger.LogError("there is an internal error occured ensure the network connection and try again");
                return null;
            }

        }

        public virtual void Add(T entity)
        {
            try
            {
                DbSet.Add(entity);
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
            }
        }
    }
}
