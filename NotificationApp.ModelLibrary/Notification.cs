namespace NotificationApp.ModelLibrary
{
    /// <summary>
    /// Represents a sent notification with message content and timestamp.
    /// </summary>
    public class Notification
    {
        public string Message { get; set; } = string.Empty;  // Notification body
        public DateTime SentDate { get; set; }                // Auto-set on creation

        /// <summary>
        /// Creates notification; timestamps it to current time.
        /// </summary>
        public Notification(string message)
        {
            Message = message;
            SentDate = DateTime.Now;
        }
    }

}