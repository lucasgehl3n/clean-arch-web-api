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
        public void Insert<T>(T entity) where T : AbstractEntity;
        public void Update<T>(T entity) where T : AbstractEntity;
        public void Delete<T>(T entity) where T : AbstractEntity;
        public List<T> Select<T>() where T : AbstractEntity;
    }
}