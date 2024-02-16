using Microsoft.EntityFrameworkCore;
using Statistic.Domain.Entities;
using Statistic.Domain.Repositories;
using Statistic.Infrastructure.Data;

namespace Statistic.Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly StatisticDbContext _context;

    public AddressRepository(StatisticDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Address>> GetAll()
    {
        return await _context.Addresses!.ToListAsync();
    }
}