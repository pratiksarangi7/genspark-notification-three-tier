using NotificationApp.DALLibrary;
using NotificationApp.ModelLibrary;

namespace NotificationApp.BLLibrary
{
    /// <summary>
    /// Business logic layer for user CRUD operations.
    /// </summary>
    public class UserService
    {
        private readonly UserDbRepository _userRepository = new();  // User data store

        /// <summary>Creates new user</summary>
        public User? CreateUser(string name, string email, string phoneNumber)
        {
            
            User u = new User(name, email, phoneNumber);
            return _userRepository.Create(u);
        }

        /// <summary>Retrieves user by ID</summary>
        public User? GetUser(int id)
        {
            return _userRepository.Get(id);
        }

        /// <summary>Deletes user by ID</summary>
        public User? DeleteUser(int id)
        {
            return _userRepository.Delete(id);
        }

        /// <summary>Returns all registered users</summary>
        public List<User>? GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        /// <summary>Replaces user details at given ID.</summary>
        public User UpdateUser(int id, string newName, string newEmail, string newPhone)
        {
            User newUser = new(newName, newEmail, newPhone);
            _userRepository.Update(id, newUser);
            return newUser;
        }
    }
}