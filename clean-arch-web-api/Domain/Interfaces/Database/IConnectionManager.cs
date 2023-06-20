using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces.Database
{
    public interface IConnectionManager
    {
        public DbConnection GetOpenConnection();
        public void CloseConnection(DbConnection dbConnection);
    }
}