using CleanArch.Domain.Interfaces.Database;
using MySqlConnector;
using System.Data.Common;

namespace clean_arch_web_api.Domain.Database
{
    public class MySQLConnection : IConnectionDatabase
    {
        protected MySqlConnection connection;
        protected string connectionString;

        public MySQLConnection(string connectionString)
        {
            this.connectionString = connectionString;
            OpenConnection();
        }

        public void OpenConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
            connection.Dispose();
        }

        public DbConnection GetConnection()
        {
            return connection;
        }
    }
}
