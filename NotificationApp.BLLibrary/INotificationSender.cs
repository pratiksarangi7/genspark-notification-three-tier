using NotificationApp.ModelLibrary;

namespace NotificationApp.BLLibrary
{
    /// <summary>
    /// Contract for sending notifications via selected channel.
    /// </summary>
    public interface INotificationSender
    {
        /// <summary>Sends notification to the user.</summary>
        void Send(User user, Notification notification);
    }
}