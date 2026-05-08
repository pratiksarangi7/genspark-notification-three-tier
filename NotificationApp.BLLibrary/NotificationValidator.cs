using System.Text.RegularExpressions;
using NotificationApp.ModelLibrary;

namespace NotificationApp.BLLibrary
{
    /// <summary>
    /// Validates notification messages and user contact details
    /// before a notification is sent.
    /// </summary>
    public class NotificationValidator
    {
        // Declared variables such that if business logic changes in future, we have
        // change at one place only
        private const int MinMessageLength = 5;
        private const int MaxSmsLength = 160;

        // Email pattern: sample: abc@def.ghi
        private static readonly Regex EmailRegex = new(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Phone pattern: optional + then 10 digits
        private static readonly Regex PhoneRegex = new(
            @"^\+?[\d\s\-\.]{10}$",
            RegexOptions.Compiled);

        /// <summary>
        /// Validates message rules (non-empty, minimum length).
        /// Throws ArgumentException if fails.
        /// </summary>
        public void ValidateMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Message cannot be empty.");
            }

            if (message.Length < MinMessageLength)
            {
                throw new ArgumentException(
                    $"Message must be at least {MinMessageLength} characters long. Current length: {message.Length}.");
            }
        }

        /// <summary>
        /// Validates that the user has a valid email address.
        /// Throws ArgumentException on failure.
        /// </summary>
        public void ValidateEmailRecipient(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException(
                    $"User '{user.Name}' does not have an email address. Cannot send email notification.");
            }

            if (!EmailRegex.IsMatch(user.Email))
            {
                throw new ArgumentException(
                    $"User '{user.Name}' has an invalid email address: '{user.Email}'.");
            }
        }

        /// <summary>
        /// Validates that the user has a valid phone number and that
        /// the SMS message does not exceed 160 characters.
        /// Throws ArgumentException on failure.
        /// </summary>
        public void ValidateSmsRecipient(User user, string message)
        {
            if (string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                throw new ArgumentException(
                    $"User '{user.Name}' does not have a phone number. Cannot send SMS notification.");
            }

            if (!PhoneRegex.IsMatch(user.PhoneNumber))
            {
                throw new ArgumentException(
                    $"User '{user.Name}' has an invalid phone number: '{user.PhoneNumber}'.");
            }

            if (message.Length > MaxSmsLength)
            {
                throw new ArgumentException(
                    $"SMS message exceeds the {MaxSmsLength}-character limit. Current length: {message.Length}.");
            }
        }
    }
}
