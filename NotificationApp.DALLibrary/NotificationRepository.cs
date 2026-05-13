using Microsoft.EntityFrameworkCore;
using NotificationApp.ModelLibrary;

namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// Notification storage repository
    /// </summary>
    public class NotificationRepository : AbstractRepository<int, Notification>
    {
        // Static counter: acts as ID sequence
        public override Notification? Get(int key)
        {
            Notification? notification=context.Notifications.Include(n=>n.User).FirstOrDefault(n=>n.Id==key);
            return notification;
        }
    }
}