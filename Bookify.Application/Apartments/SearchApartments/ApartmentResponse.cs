namespace Bookify.Application.Apartments.SearchApartments
{
    public sealed class ApartmentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; init; }
        public string Currency { get; init; }
        public AddressResponse Address { get; set; }
    }
}
