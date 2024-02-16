using Microsoft.EntityFrameworkCore;
using Statistic.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Statistic.Domain.Repositories;
using Statistic.Infrastructure.Repositories;

namespace Statistic.Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddTransient<IVisitorRepository, VisitorRepository>();
        service.AddTransient<IAddressRepository, AddressRepository>();
        
        service.AddDbContext<StatisticDbContext>(options=>
            options.UseMySQL("server=localhost;Uid=bayerles;pwd=geheim;database=statistic;allowuservariables=True;SslMode=None"));
        return service;
    }
}