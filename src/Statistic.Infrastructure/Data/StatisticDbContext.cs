using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Statistic.Domain.Entities;

namespace Statistic.Infrastructure.Data;

public class StatisticDbContext : DbContext
{
    private DbSet<Visitor>? Visitors { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(
            "server=localhost;Uid=bayerles;pwd=geheim;database=statistic;allowuservariables=True;SslMode=None");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}