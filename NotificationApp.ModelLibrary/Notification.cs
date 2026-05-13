namespace NotificationApp.ModelLibrary
{
    /// <summary>
    /// Represents a sent notification with message content and timestamp.
    /// </summary>
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;  // Notification body
        public int UserId { get; set; }
        public DateTime SentDate { get; set; }
        public User User { get; set; } = null!;          // Automatically set while creation

        /// <summary>
        /// Creates notification with user link, timestamps to current time.
        /// </summary>
        public Notification(string message, int userId)
        {
            Message = message;
            UserId = userId;
            SentDate = DateTime.UtcNow;
        }
    }

}