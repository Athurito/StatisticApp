using Microsoft.EntityFrameworkCore;
using Statistic.Infrastructure.Data;

namespace Statistic.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddDbContext<StatisticDbContext>(options=>
            options.UseMySQL("server=localhost;Uid=bayerles;pwd=geheim;database=statistic;allowuservariables=True;SslMode=None"));
        return service;
    }
}