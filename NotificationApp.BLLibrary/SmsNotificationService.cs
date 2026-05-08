using NotificationApp.ModelLibrary;

namespace NotificationApp.BLLibrary
{
    /// <summary>
    /// Sends notifications via SMS channel.
    /// </summary>
    public class SmsNotificationService : INotificationSender
    {
        /// <summary>
        /// Sends SMS to user; skips if no phone number present
        /// </summary>
        public void Send(User user, Notification notification)
        {
            // Skip if no phone number
            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                Console.WriteLine($"No phone number for {user.Name}");
                return;
            }
            Console.WriteLine($"SMS sent to {user.PhoneNumber}. Message is: {notification.Message}");
        }

    }
}