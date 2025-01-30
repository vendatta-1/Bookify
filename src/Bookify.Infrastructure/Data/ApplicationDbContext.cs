

using Bookify.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private IPublisher Publisher { get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher) : base(options)
        {
            Publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //to reg all configuration of the same Assembly as Application DbContext 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEvents();

            return result;

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
