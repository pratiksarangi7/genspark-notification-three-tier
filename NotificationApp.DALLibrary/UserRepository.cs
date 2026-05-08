using System.Security.Cryptography;
using NotificationApp.ModelLibrary;

namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// User storage repository.
    /// </summary>
    public class UserRepository : AbstractRepository<string, User>
    {
        // Static counter: acts as ID sequence
        static string userId = "1";

        public UserRepository()
        {
            _items = new Dictionary<string, User>();
        }

        /// <summary>
        /// Stores user with next ID.
        /// </summary>
        public override User Create(User item)
        {
            // Increment ID counter
            int id = Convert.ToInt32(userId);
            id += 1;
            userId = id.ToString();
            Console.WriteLine($"user id is: {userId}");
            _items[userId] = item;
            return item;
        }
    }
}