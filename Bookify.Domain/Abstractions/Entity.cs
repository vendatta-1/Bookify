namespace Bookify.Domain.Abstractions
{
    public abstract class Entity : IComparable<Entity>, IEquatable<Entity>, IDomainEvent
    {

        private readonly IList<IDomainEvent> _events;
        public Guid Id { get; init; }

        protected Entity(Guid id)
        {
            Id = id;
            _events = new List<IDomainEvent>();
        }
        public int CompareTo(Entity? other)
        {
            if (other == null) return 1;
            return Id == other.Id ? 1 : -1;
        }

        public bool Equals(Entity? other)
            => other is not null && Id == other.Id;

        public void ClearDomainEvents()
        {
            _events.Clear();
        }

        public IEnumerable<IDomainEvent> GetDomainEvents()
        {
            return _events;
        }
        protected bool RaiseDomainEvent(IDomainEvent domainEvent)
        {
            try
            {
                _events.Add(domainEvent);

                return _events.Contains(domainEvent);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
