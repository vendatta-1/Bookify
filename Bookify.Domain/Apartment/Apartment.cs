using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookify.Domain.Abstraction;
using Bookify.Domain.Common;

namespace Bookify.Domain.Apartment
{
    public sealed class Apartment:Entity
    {

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

        public Description Description { get;private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }

        public List<Amenity> Amenities { get; private set; } = new();

    }
}
