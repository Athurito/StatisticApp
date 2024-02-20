using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Statistic.Wpf.Messages;

public class PdfErrorMessage : ValueChangedMessage<string>
{
    public PdfErrorMessage(string value) : base(value)
    {
    }
}