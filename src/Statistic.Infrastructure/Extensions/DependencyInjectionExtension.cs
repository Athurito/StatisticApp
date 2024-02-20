using Microsoft.EntityFrameworkCore;
using Statistic.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Statistic.Domain.Repositories;
using Statistic.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Statistic.Infrastructure.Configuration;


namespace Statistic.Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddTransient<IVisitorRepository, VisitorRepository>();
        service.AddTransient<IAddressRepository, AddressRepository>();
        service.AddDbContextFactory<StatisticDbContext>(options =>
            options.UseMySQL(AppSettings.ConnectionString!));
        return service;
    }
}