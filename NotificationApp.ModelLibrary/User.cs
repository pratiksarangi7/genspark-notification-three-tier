namespace NotificationApp.ModelLibrary
{
    /// <summary>
    /// Represents a user who can receive notifications.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes user with contact details: email and phone.
        /// </summary>
        public User(string name, string email, string phoneNumber)
        {
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; set; } = string.Empty;         // Display name
        public string Email { get; set; } = string.Empty;        // Email address for email notifications
        public string PhoneNumber { get; set; } = string.Empty;  // Phone number for SMS notifications
    }
}