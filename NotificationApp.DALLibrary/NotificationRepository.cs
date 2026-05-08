using NotificationApp.ModelLibrary;

namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// Notification storage repository
    /// </summary>
    public class NotificationRepository : AbstractRepository<string, Notification>
    {
        // Static counter: acts as ID sequence
        static string notifId = "1";

        public NotificationRepository()
        {
            _items = new Dictionary<string, Notification>();
        }

        /// <summary>
        /// Stores notification with next ID.
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