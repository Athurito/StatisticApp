using Statistic.Application.DTOs;
using Statistic.Domain.Entities;
using Statistic.Domain.Repositories;

namespace Statistic.Application.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }
    
    public async Task<IEnumerable<AddressDto>> GetAll()
    {
        var addresses = await _addressRepository.GetAll();
         
        return addresses.Select(ConvertToAddressDto).ToList();
    }
    
    private static AddressDto ConvertToAddressDto(Address address)
    {
        var addressDto = new AddressDto
        {
            Id = address.Id,
            ZipCode = address.ZipCode,
            Town = address.Town
        };

        return addressDto;
    }
}