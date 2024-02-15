using Microsoft.EntityFrameworkCore;
using Statistic.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Statistic.Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddDbContext<StatisticDbContext>(options=>
            options.UseMySQL("server=localhost;Uid=bayerles;pwd=geheim;database=statistic;allowuservariables=True;SslMode=None"));
        return service;
    }
}