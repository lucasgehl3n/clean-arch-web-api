using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using static CleanArch.Domain.Database.ConnectionGenerate;

namespace CleanArch.Domain.Interfaces.Database
{
    public interface IConnectionManager
    {
        public DbConnection GetOpenConnection();
        public void CloseConnection(DbConnection dbConnection);
        public DatabaseType GetDatabaseType();
    }
}