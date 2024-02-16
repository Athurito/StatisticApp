using Microsoft.EntityFrameworkCore;
using Statistic.Domain.Entities;
using Statistic.Domain.Repositories;
using Statistic.Infrastructure.Data;

namespace Statistic.Infrastructure.Repositories;

public class VisitorRepository : IVisitorRepository
{
    private readonly StatisticDbContext _context;

    public VisitorRepository(StatisticDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateVisitor(Visitor visitor)
    {
        await _context.Visitors!.AddAsync(visitor);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Visitor>> GetAll()
    {
        return await _context.Visitors!
            .Include(r => r.VisitorInterests)
            .ToListAsync();
    }
}