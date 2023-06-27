using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using System.Reflection;
using CleanArch.Domain.Abstracts;
using System.Data.Common;
using CleanArch.Domain.Interfaces.Database;

namespace CleanArch.Domain.Database
{
    public class PostgreSqlConnection: IConnectionDatabase
    {
        protected NpgsqlConnection connection;
		protected string connectionString;

		public PostgreSqlConnection(string connectionString)
		{
			this.connectionString = connectionString;
            OpenConnection();
		}

		public void OpenConnection()
		{
			connection = new NpgsqlConnection(connectionString);
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