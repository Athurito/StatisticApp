using Statistic.Domain.Entities;

namespace Statistic.Domain.Repositories;

public interface IAddressRepository
{
    public IEnumerable<Address> GetAll();
}