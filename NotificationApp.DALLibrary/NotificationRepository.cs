using NotificationApp.ModelLibrary;

namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// Notification storage with auto-incrementing string IDs.
    /// </summary>
    public class NotificationRepository : AbstractRepository<string, Notification>
    {
        // Static counter shared across instances — acts as ID sequence
        static string notifId = "1";

        public NotificationRepository()
        {
            _items = new Dictionary<string, Notification>();
        }

        /// <summary>
        /// Stores notification with next auto-incremented ID.
        /// </summary>
        public override Notification Create(Notification item)
        {
            // Increment ID counter
            int id = Convert.ToInt32(notifId);
            id += 1;
            notifId = id.ToString();
            _items[notifId] = item;
            return _items[notifId];
        }
    }
}