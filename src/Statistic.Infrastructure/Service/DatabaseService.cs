using System.Reflection;
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

    public async Task SeedDataBaseAsync()
    {
        await using var context = await _context.CreateDbContextAsync();

        if (!await context.Addresses!.AnyAsync())
        {
            var assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "Statistic.Infrastructure.addresses.sql";

            await using var stream = assembly.GetManifestResourceStream(resourceName);
            
            using var reader = new StreamReader(stream!);
            
            var sqlScript = await reader.ReadToEndAsync();
            
            await context.Database.ExecuteSqlRawAsync(sqlScript);
        }
    }
}