using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Interfaces.Database;
using CleanArch.Domain.Interfaces.Repository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Reflection;
using Dapper;
using System.Linq;

namespace CleanArch.Persintence.Abstracts
{
    public abstract class AbstractRepositoryDb<ImplementedClass> : IRepository<ImplementedClass> where ImplementedClass : AbstractEntity
    {
        private readonly IConnectionManager _connectionManager;
        public AbstractRepositoryDb(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }


        public IEnumerable<ImplementedClass> GetAll()
        {
            using (var connection = _connectionManager.GetOpenConnection() as NpgsqlConnection)
            {
                string tableName = typeof(ImplementedClass).Name;
                string query = $"SELECT * FROM {tableName}";

                return connection.Query<ImplementedClass>(query);
            }
        }


        public ImplementedClass GetById(int id)
        {
            using (var connection = _connectionManager.GetOpenConnection() as NpgsqlConnection)
            {
                string tableName = typeof(ImplementedClass).Name;
                string query = $"SELECT * FROM {tableName} WHERE id = @Id";

                return connection.QueryFirstOrDefault<ImplementedClass>(query, new { Id = id });
            }
        }

        public IEnumerable<ImplementedClass> GetByProperty(string propertyName, string propertyValue)
        {
            using (var connection = _connectionManager.GetOpenConnection() as NpgsqlConnection)
            {
                string tableName = typeof(ImplementedClass).Name;
                string query = $"SELECT * FROM {tableName} WHERE {propertyName} = {propertyValue}";

                return connection.Query<ImplementedClass>(query);
            }
        }


        public void Add(ImplementedClass entity)
        {
            using (var connection = _connectionManager.GetOpenConnection() as NpgsqlConnection)
            {
                string tableName = typeof(ImplementedClass).Name;
                PropertyInfo[] properties = typeof(ImplementedClass).GetProperties();

                properties = properties.Where(p => p.Name != "Id").ToArray();

                string columns = string.Join(", ", properties.Select(p => p.Name));
                string values = string.Join(", ", properties.Select(p => $"@{p.Name}"));

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
                Console.WriteLine(query);
                connection.Execute(query, entity);
            }
        }

        public void Remove(ImplementedClass entity)
        {
            using (var connection = _connectionManager.GetOpenConnection() as NpgsqlConnection)
            {
                string tableName = typeof(ImplementedClass).Name;
                string query = $"DELETE FROM {tableName} WHERE id = @Id";
                connection.Execute(query, new { Id = entity.Id });
            }
        }


        public void Update(ImplementedClass entity)
        {
            using (var connection = _connectionManager.GetOpenConnection() as NpgsqlConnection)
            {
                string tableName = typeof(ImplementedClass).Name;
                PropertyInfo[] properties = typeof(ImplementedClass).GetProperties();

                properties = properties.Where(p => p.Name != "Id").ToArray();

                string setStatements = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

                string query = $"UPDATE {tableName} SET {setStatements} WHERE Id = @Id";
                connection.Execute(query, entity);
            }
        }
    }
}
