namespace Statistic.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        return service;
    }
}