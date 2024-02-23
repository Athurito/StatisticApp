using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Statistic.Wpf.Messages;

/// <summary>
/// Represents a message that is sent when an error occurs during application startup.
/// </summary>
public class ApplicationStartErrorMessage : ValueChangedMessage<string>
{
    public ApplicationStartErrorMessage(string value) : base(value)
    {
    }
}