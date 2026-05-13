using NotificationApp.DALLibrary;
using NotificationApp.ModelLibrary;

namespace NotificationApp.BLLibrary
{
    /// <summary>
    /// Service for handling notification creation, validation, and dispatch.
    /// </summary>
    public class NotificationService
    {
        private readonly NotificationRepository notificationRepository = new();  // Stores sent notifications
        private readonly NotificationValidator _validator = new();             // Validation before sending

        /// <summary>
        /// Validates, stores, and sends a notification to the user.
        /// Throws ArgumentException if validation fails.
        /// </summary>
        public void NotifyUser(int userId, string message, INotificationSender sender, UserService userService)
        {
            // Validate message is not empty and has at least 5 characters
            _validator.ValidateMessage(message);
            User u = userService.GetUser(userId);
            // Validate email if sending via Email
            if (sender is EmailNotificationService)
            {
                _validator.ValidateEmailRecipient(u);
            }

            // Validate phone number and SMS length if sending via SMS
            if (sender is SmsNotificationService)
            {
                _validator.ValidateSmsRecipient(u, message);
            }

            // Create, store, and send
            Notification n = new(message, userId);
            notificationRepository.Create(n);
            sender.Send(u, n);
        }

        /// <summary>Retrieves a single notification by ID.</summary>
        public Notification GetSentNotificationDetails(int id)
        {
            var result = notificationRepository.Get(id);
            return result!;
        }

        /// <summary>Returns all sent notifications.</summary>
        public List<Notification> GetAllNotifications()
        {
            var result = notificationRepository.GetAll();
            return result!;
        }
        /// <summary>Returns all notifications sent to particular user.</summary>
        public List<Notification> GetNotificationsByUserId(int id)
        {
            var result=notificationRepository.GetAll()!.Where((notif)=>notif.UserId==id);
            return [.. result];
        }
    }
}