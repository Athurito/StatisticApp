using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Statistic.Application.Pdf.HelperModels;
using Statistic.Wpf.Messages;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Statistic.Wpf.View;

public partial class StatisticWindow : Window, IRecipient<DirectoryMessage>, IRecipient<PdfErrorMessage>,
    IRecipient<PdfSuccessMessage>, IRecipient<ApplicationStartErrorMessage>
{
    public StatisticWindow()
    {
        InitializeComponent();
        WeakReferenceMessenger.Default.RegisterAll(this);
    }

    public void Receive(DirectoryMessage message)
    {
        FolderBrowserDialog fbd = new();
        var dialogResult = fbd.ShowDialog();
        var dialogHelper = new DialogHelper
        {
            DialogResult = dialogResult != System.Windows.Forms.DialogResult.Cancel,
            SelectedPath = fbd.SelectedPath
        };
        message.Reply(dialogHelper);
    }

    public void Receive(PdfErrorMessage message)
    {
        ShowErrorMessageBox(message.Value);
    }
   
    public void Receive(PdfSuccessMessage message)
    {
        MessageBox.Show(message.Value,"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void Receive(ApplicationStartErrorMessage message)
    {
        ShowErrorMessageBox(message.Value);
        Close();
    }
    
    private static void ShowErrorMessageBox(string message)
    {
        MessageBox.Show(message,"Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

}