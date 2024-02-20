using Statistic.Application.Pdf;
using Statistic.Application.Services;

namespace Statistic.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddTransient<IAddressService, AddressService>();
        service.AddTransient<IVisitorService, VisitorService>();
        service.AddTransient<IVisitorStatisticService, VisitorStatisticService>();
        service.AddTransient<IPdfService, PdfService>();
        
        return service;
    }
}