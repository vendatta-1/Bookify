using Bookify.Domain.Abstractions;
using Bookify.Domain.Common;

namespace Bookify.Domain.Apartments
{
    public sealed class Apartment : Entity
    {
        private Apartment() { }
        public Apartment
            (Guid id,
                Money cleaningFee,
                Money price,
                Description description,
                Name name,
                Address address,
                List<Amenity> amenities) : base(id)
        {
            CleaningFee = cleaningFee;
            Price = price;
            Description = description;
            Name = name;
            Address = address;
            Amenities = amenities;
        }

        public Money CleaningFee { get; private set; }
        public Money Price { get; private set; }
        public DateTime LastBookedOnUtc { get; internal set; }
        public Description Description { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }

        public List<Amenity> Amenities { get; private set; } = new();

    }
}
