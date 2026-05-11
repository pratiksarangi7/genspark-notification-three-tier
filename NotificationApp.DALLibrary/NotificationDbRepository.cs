using NotificationApp.ModelLibrary;
using Npgsql;

namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// Connects to the Database, to perform CRUD operations on Notifications table
    /// </summary>
    public class NotificationDbRepository
    {
        NpgsqlConnection connection;
        public NotificationDbRepository()
        {
            connection = ConnectionHelper.GetConnection();
        }

        public Notification? Create(Notification item)
        {
            try
            {
                connection.Open();
                string query = $"Insert into notifications(message, user_id, sent_date) values ('{item.Message}', '{item.UserId}', '{item.SentDate}')";
                var command = new NpgsqlCommand(query, connection);
                var result = command.ExecuteNonQuery();
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public Notification? Get(int id)
        {
            try
            {
                connection.Open();
                string query = $"select * from notifications where id={id}";
                var command = new NpgsqlCommand(query, connection);
                var result = command.ExecuteReader();
                if (result.Read())
                {
                    return new Notification(
                    result.GetString(1),
                    result.GetInt32(2).ToString()
                )
                    {
                        Id = result.GetInt32(0),
                        SentDate = result.GetDateTime(3)
                    };

                }
                return null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<Notification>? GetAll()
        {
            try
            {
                connection.Open();
                string query = $"select * from notifications";
                var command = new NpgsqlCommand(query, connection);
                var result = command.ExecuteReader();
                List<Notification> notifications = new();
                while (result.Read())
                {
                    notifications.Add(new Notification(result.GetString(1), result.GetInt32(2).ToString()) { Id = result.GetInt32(0), SentDate = result.GetDateTime(3) });
                }

                return notifications;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }



    }
}