using NotificationApp.ModelLibrary;

namespace NotificationApp.BLLibrary
{
    /// <summary>
    /// Sends notifications via email.
    /// </summary>
    public class EmailNotificationService : INotificationSender
    {
        /// <summary>
        /// Sends email to user; skips if no email present.
        /// </summary>
        public void Send(User user, Notification notification)
        {
            // Skip if no email address
            if (string.IsNullOrEmpty(user.Email))
            {
                Console.WriteLine($"No email address for {user.Name}");
                return;
            }
            Console.WriteLine($"Email sent to {user.Email}. Message is: {notification.Message}");
        }

    }
}