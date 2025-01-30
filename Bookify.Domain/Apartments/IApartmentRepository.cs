namespace Bookify.Domain.Apartments
{
    public interface IApartmentRepository
    {
        Task<IEnumerable<Apartment>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Apartment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
