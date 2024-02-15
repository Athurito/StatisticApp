using Statistic.Application.DTOs;

namespace Statistic.Application.Services;

public interface IAddressService
{
    /// <summary>
    /// Retrieves all addresses.
    /// </summary>
    /// <returns>
    /// Returns a collection of AddressDto objects representing all addresses.
    /// </returns>
    public Task<IEnumerable<AddressDto>> GetAll();
}