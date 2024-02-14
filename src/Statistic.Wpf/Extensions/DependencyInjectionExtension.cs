using Microsoft.Extensions.DependencyInjection;
using Statistic.Wpf.View;
using Statistic.Wpf.ViewModel;

namespace Statistic.Wpf.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddWpf(this IServiceCollection service)
    {
        service.AddTransient<StatisticWindow>();
        service.AddTransient<StatisticViewModel>();
        return service;
    }
}