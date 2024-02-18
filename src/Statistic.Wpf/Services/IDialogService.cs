using System.Windows;

namespace Statistic.Wpf.Services;

public interface IDialogService
{
    /// <summary>
    /// Opens a dialog of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the dialog window.</typeparam>
    /// <returns>True if the dialog is successfully opened; otherwise, false.</returns>
    public bool? OpenDialog<T>() where T : Window;
}