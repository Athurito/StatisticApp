using Microsoft.EntityFrameworkCore;
using Statistic.Domain.Entities;
using Statistic.Domain.Repositories;
using Statistic.Infrastructure.Data;

namespace Statistic.Infrastructure.Repositories;

public class VisitorRepository : IVisitorRepository
{
    private readonly IDbContextFactory<StatisticDbContext> _context;

    public VisitorRepository(IDbContextFactory<StatisticDbContext> context)
    {
        _context = context;
    }
    
    public async Task CreateVisitor(Visitor visitor)
    {
        await using var context = await _context.CreateDbContextAsync();
        await context.Visitors!.AddAsync(visitor);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Visitor>> GetAll()
    {
        await using var context = await _context.CreateDbContextAsync();
        return await context.Visitors!
            .Include(r => r.VisitorInterests)
            .Include(r => r.Address)
            .ToListAsync();
    }
}