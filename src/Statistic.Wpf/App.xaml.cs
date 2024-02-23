using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Statistic.Application.Extensions;
using Statistic.Infrastructure.Configuration;
using Statistic.Infrastructure.Extensions;
using Statistic.Wpf.Extensions;
using Statistic.Wpf.View;
using Statistic.Wpf.ViewModel;

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
        ConfigureConfiguration();
        OpenMainWindow();
    }

    private void OpenMainWindow()
    {
        MainWindow = _serviceProvider!.GetRequiredService<StatisticWindow>();
        MainWindow.DataContext = _serviceProvider!.GetRequiredService<StatisticViewModel>();
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

    private static void ConfigureConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
#if WORKING
        AppSettings.ConnectionString = builder.GetConnectionString("home");
#else
        AppSettings.ConnectionString = builder.GetConnectionString("school");
#endif
    }
}