using System;
using CleanArch.Domain.Interfaces.Database;

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
                case DatabaseType.SQLServer:
                    break;
                default:
                    throw new ArgumentException("Database type not supported.");
            }

            return null;
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

        public enum DatabaseType
        {
            PostgreSQL,
            SQLServer,
        }
    }
}
