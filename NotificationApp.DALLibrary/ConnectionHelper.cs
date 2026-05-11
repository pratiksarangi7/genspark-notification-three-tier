using Npgsql;

namespace NotificationApp.DALLibrary
{
    public class ConnectionHelper
    {
        static readonly string connectionStr="Host=localhost;Port=5432;Database=notificationappdb;Username=postgres;Password=Pratik@Postgres";
        public static NpgsqlConnection GetConnection()
        {
            NpgsqlConnection connection=new(connectionStr);
            return connection;
        }

    }
}