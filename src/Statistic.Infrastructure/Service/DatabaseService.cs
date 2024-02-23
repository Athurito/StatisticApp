using Microsoft.EntityFrameworkCore;
using Statistic.Infrastructure.Data;

namespace Statistic.Infrastructure.Service;

public class DatabaseService : IDatabaseService
{
    private readonly IDbContextFactory<StatisticDbContext> _context;
    
    public DatabaseService(IDbContextFactory<StatisticDbContext> context)
    {
        _context = context;
    }

    public void EnsureDataBase()
    {
        var context = _context.CreateDbContext(); 
        context.Database.EnsureCreated();
    }
}