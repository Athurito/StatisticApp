using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Statistic.Application.Extensions;
using Statistic.Infrastructure.Extensions;
using Statistic.Wpf.Extensions;
using Statistic.Wpf.View;

namespace Statistic.Wpf;

public partial class App : System.Windows.Application
{
    private IServiceProvider? _serviceProvider;
    public App()
    {
        RegisterServices();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = _serviceProvider!.GetRequiredService<StatisticWindow>();
        MainWindow.ShowDialog();
    }

    private void RegisterServices()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddApplication();
        services.AddInfrastructure();
        services.AddWpf();

        _serviceProvider = services.BuildServiceProvider();
    }
}