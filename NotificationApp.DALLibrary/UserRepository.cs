using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using NotificationApp.ModelLibrary;

namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// User storage repository.
    /// </summary>
    public class UserRepository : AbstractRepository<int, User>
    {
        public override User? Get(int key)
        {
            var User=context.Users.FirstOrDefault(u=>u.Id==key);
            return User;
        }
    }
}