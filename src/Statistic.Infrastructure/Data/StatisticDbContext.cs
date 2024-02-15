using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Statistic.Domain.Entities;

namespace Statistic.Infrastructure.Data;

public class StatisticDbContext : DbContext
{
    private DbSet<Visitor>? Visitors { get; set; }

    public StatisticDbContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}