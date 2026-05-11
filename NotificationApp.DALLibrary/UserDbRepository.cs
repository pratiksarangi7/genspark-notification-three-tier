using NotificationApp.ModelLibrary;
using Npgsql;

namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// connects to the database to perform CRUD on User table
    /// </summary>
    public class UserDbRepository
    {
        NpgsqlConnection connection;
        public UserDbRepository()
        {
            connection = ConnectionHelper.GetConnection();
        }
        public User? Create(User item)
        {
            try
            {
                connection.Open();
                string query = $"Insert into users(name, email, phone_number) values ('{item.Name}', '{item.Email}', '{item.PhoneNumber}')";
                var command = new NpgsqlCommand(query, connection);
                var result = command.ExecuteNonQuery();
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public User? Get(int id)
        {
            try
            {
                connection.Open();
                string query = $"select * from users where id={id}";
                var command = new NpgsqlCommand(query, connection);
                var result = command.ExecuteReader();
                if (result.Read())
                {
                    return new User(result.GetString(1), result.GetString(2), result.GetString(3));
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<User>? GetAll()
        {
            try
            {
                connection.Open();
                string query = $"select * from users";
                var command = new NpgsqlCommand(query, connection);
                var result = command.ExecuteReader();
                List<User> users = new();
                while (result.Read())
                {
                    users.Add(new User(result.GetString(1), result.GetString(2), result.GetString(3)));
                }

                return users;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public User? Update(int id, User u)
        {
            try
            {
                connection.Open();
                string query = $"update users set name='{u.Name}', email='{u.Email}', phone_number='{u.PhoneNumber}' where id={u.Id}";
                var command = new NpgsqlCommand(query, connection);
                var rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0) return null;
                u.Id = id;
                return u;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public User? Delete(int id)
        {
            try
            {
                connection.Open();
                var existing = Get(id);
                string query = $"delete from users where id={id}";
                var command = new NpgsqlCommand(query, connection);
                var rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0) return null;
                return existing;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }



    }
}