using Statistic.Domain.Entities;

namespace Statistic.Domain.Repositories;

public interface IAddressRepository
{
    /// <summary>
    /// Retrieves all addresses from the address repository.
    /// </summary>
    /// <returns>
    /// Returns a collection of Address objects representing all addresses.
    /// </returns>
    public Task<IEnumerable<Address>> GetAll();
}