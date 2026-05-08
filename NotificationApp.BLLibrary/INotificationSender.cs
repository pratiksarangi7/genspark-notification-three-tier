using NotificationApp.ModelLibrary;

namespace NotificationApp.BLLibrary
{
    /// <summary>
    /// Contract for sending notifications via a specific channel.
    /// </summary>
    public interface INotificationSender
    {
        /// <summary>Delivers notification to the user.</summary>
        void Send(User user, Notification notification);
    }
}