using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users.Events
{
    public sealed record UserUpdatedDomainEvent(Guid id) : IDomainEvent
    {
    }
}
