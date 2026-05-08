using NotificationApp.DALLibrary;
using NotificationApp.ModelLibrary;

namespace NotificationApp.BLLibrary
{
    /// <summary>
    /// Business logic layer for user CRUD operations.
    /// </summary>
    public class UserService
    {
        private readonly UserRepository _userRepository = new();  // User data store

        /// <summary>Creates new user</summary>
        public User CreateUser(string name, string email, string phoneNumber)
        {
            
            User u = new User(name, email, phoneNumber);
            return _userRepository.Create(u);
        }

        /// <summary>Retrieves user by ID</summary>
        public User GetUser(string id)
        {
            User u = _userRepository.Get(id)!;
            return u;
        }

        /// <summary>Deletes user by ID</summary>
        public User DeleteUser(string id)
        {
            User u = _userRepository.Delete(id)!;
            return u;
        }

        /// <summary>Returns all registered users</summary>
        public List<User> GetAllUsers()
        {
            List<User> list = _userRepository.GetAll()!;
            return list;
        }

        /// <summary>Replaces user details at given ID.</summary>
        public User UpdateUser(string id, string newName, string newEmail, string newPhone)
        {
            User newUser = new(newName, newEmail, newPhone);
            _userRepository.Update(id, newUser);
            return newUser;
        }
    }
}