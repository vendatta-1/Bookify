

using Bookify.Application.Abstractions.Exceptions;
using Bookify.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Bookify.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private IPublisher Publisher { get; }
        private ILogger<ApplicationDbContext> Logger { get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher, ILogger<ApplicationDbContext> logger) : base(options)
        {
            Publisher = publisher;
            Logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //to reg all configuration of the same Assembly as Application DbContext 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);

                await PublishDomainEvents();

                return result;

            }
            catch (DBConcurrencyException e)
            {
                Logger.LogError(e, e.Message);
                throw new ConcurrencyException("concurrency exception occured while try to save changes see inner Exception for more details", e);
            }


        }


        private async Task PublishDomainEvents()
        {
            var domainEvents = ChangeTracker
                .Entries<Entity>()
                .Select(x => x.Entity)
                .SelectMany(entity => entity.GetDomainEvents())
                .ToList();
            foreach (var domainEvent in domainEvents)
            {
                await Publisher.Publish(domainEvent);
            }
        }

    }

}
