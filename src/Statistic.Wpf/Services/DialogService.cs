using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Statistic.Wpf.Services;

public class DialogService : IDialogService
{
    private readonly IServiceProvider _serviceProvider;

    public DialogService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public bool? OpenDialog<T>() where T : Window
    {
        return _serviceProvider.GetRequiredService<T>().ShowDialog();
    }
}