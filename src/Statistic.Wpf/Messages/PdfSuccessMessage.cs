using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Statistic.Wpf.Messages;

public class PdfSuccessMessage : ValueChangedMessage<string>
{
    public PdfSuccessMessage(string value) : base(value)
    {
    }
}