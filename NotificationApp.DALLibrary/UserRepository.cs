using System.Security.Cryptography;
using NotificationApp.ModelLibrary;

namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// User storage with auto-incrementing string IDs.
    /// </summary>
    public class UserRepository : AbstractRepository<string, User>
    {
        // Static counter shared across instances — acts as ID sequence
        static string userId = "1";

        public UserRepository()
        {
            _items = new Dictionary<string, User>();
        }

        /// <summary>
        /// Stores user with next auto-incremented ID.
        /// </summary>
        public override User Create(User item)
        {
            // Increment ID counter
            int id = Convert.ToInt32(userId);
            id += 1;
            userId = id.ToString();
            System.Console.WriteLine($"user id is: {userId}");
            _items[userId] = item;
            return item;
        }
    }
}