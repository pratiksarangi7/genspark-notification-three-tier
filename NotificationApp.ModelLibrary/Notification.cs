namespace NotificationApp.ModelLibrary
{
    /// <summary>
    /// Represents a sent notification with message content and timestamp.
    /// </summary>
    public class Notification
    {
        public string Message { get; set; } = string.Empty;  // Notification body
        public string UserId { get; set; } = string.Empty;  
        public DateTime SentDate { get; set; }                // Automatically set while creation

        /// <summary>
        /// Creates notification with user link, timestamps to current time.
        /// </summary>
        public Notification(string message, string userId)
        {
            Message = message;
            UserId = userId;
            SentDate = DateTime.Now;
        }
    }

}