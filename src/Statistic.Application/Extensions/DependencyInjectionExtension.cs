using Statistic.Application.Services;

namespace Statistic.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddTransient<IAddressService, AddressService>();
        service.AddTransient<IVisitorService, VisitorService>();
        
        return service;
    }
}