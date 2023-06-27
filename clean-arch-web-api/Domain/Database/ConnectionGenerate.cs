using System;
using clean_arch_web_api.Domain.Database;
using CleanArch.Domain.Interfaces.Database;
using MySqlConnector;

namespace CleanArch.Domain.Database
{
    public static class ConnectionGenerate
    {
        public static IConnectionDatabase BuildConnectionString(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.PostgreSQL:
                    return new PostgreSqlConnection(BuildPostgreSQLConnection());
                case DatabaseType.MySql:
                    return new MySQLConnection(BuildMySQLConnection());
                default:
                    throw new ArgumentException("Database type not supported.");
            }
        }

        private static string BuildPostgreSQLConnection()
        {
            var server = "teste-postgres";
            var port = "5432";
            var database = "projetoearq";
            var username = "postgres";
            var password = "jorge";

            return $"Server={server};Port={port};Database={database};User Id={username};Password={password};";
        }

        private static string BuildMySQLConnection()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "meu-mysql";
            conn_string.UserID = "root";
            conn_string.Password = "jorge";
            conn_string.Database = "PAS";

            return conn_string.ToString();
        }


        public enum DatabaseType
        {
            PostgreSQL,
            MySql,
        }
    }
}
