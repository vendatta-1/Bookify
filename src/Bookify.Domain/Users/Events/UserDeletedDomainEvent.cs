using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users.Events
{
    public sealed record UserDeletedDomainEvent(Guid id) : IDomainEvent
    {
    }
}
