using Microsoft.EntityFrameworkCore;
using Statistic.Domain.Entities;
using Statistic.Domain.Repositories;
using Statistic.Infrastructure.Data;

namespace Statistic.Infrastructure.Repositories;

public class AddressRepository : BaseRepository, IAddressRepository
{
    private readonly IDbContextFactory<StatisticDbContext> _context;

    public AddressRepository(IDbContextFactory<StatisticDbContext> context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Address>> GetAll()
    {
        await using var context = await _context.CreateDbContextAsync();
        EnsureConnection(context);
        return await context.Addresses!.ToListAsync();
    }
}