namespace Statistic.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        return service;
    }
}