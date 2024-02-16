using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Statistic.Domain.Entities;

namespace Statistic.Infrastructure.Data;

public class StatisticDbContext : DbContext
{
    public DbSet<Visitor>? Visitors { get; set; }
    public DbSet<Address>? Addresses { get; set; }

    public StatisticDbContext(DbContextOptions<StatisticDbContext> options) : base(options)
    {
        
    }
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