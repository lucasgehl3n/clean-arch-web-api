using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Interfaces.Entities;

namespace CleanArch.Domain.Interfaces.Database
{
    public interface IConnectionDatabase
    {
		public void OpenConnection();
        public void CloseConnection();
        public DbConnection GetConnection();
    }
}