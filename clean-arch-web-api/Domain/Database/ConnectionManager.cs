using System.Data.Common;
using static CleanArch.Domain.Database.ConnectionGenerate;
using CleanArch.Domain.Interfaces.Database;
using System;
using System.Data;

namespace CleanArch.Domain.Database
{
    public class ConnectionManager : IConnectionManager
    {
        private IConnectionDatabase connection;
        private readonly DatabaseType dbType;

        public ConnectionManager(DatabaseType dbType)
        {
            this.dbType = dbType;
        }

        public DbConnection GetOpenConnection()
        {
            this.connection = BuildConnectionString(dbType);
            DbConnection dbConnection = connection.GetConnection();
            return dbConnection;
        }

        public void CloseConnection(DbConnection dbConnection)
        {
            dbConnection.Close();
        }

        public DatabaseType GetDatabaseType()
        {
            return dbType;
        }
    }
}