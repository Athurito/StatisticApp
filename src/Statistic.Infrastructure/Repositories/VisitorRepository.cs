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
        await using var context = _context;

        await context.Visitors!.AddAsync(visitor);
    }

    public async Task<IEnumerable<Visitor>> GetAll()
    {
        await using var context = _context;

        return await context.Visitors!.ToListAsync();
    }
}