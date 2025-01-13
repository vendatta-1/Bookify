using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Abstraction
{
    public abstract class Entity : IComparable<Entity>,IEquatable<Entity>
    {
        public Guid Id { get; init; }

        protected Entity(Guid id)
        {
            Id = id;
        }
        public int CompareTo(Entity? other)
        {
            if (other == null) return 1;
            return Id == other.Id ? 1 : -1;
        }

        public bool Equals(Entity? other)
            => other is not null && Id == other.Id;
    }
}
