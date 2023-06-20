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

        public void Insert<T>(T entity) where T:AbstractEntity
        {
            OpenConnection();

            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;

                // Obtém o nome da tabela com base no tipo da entidade
                string tableName = typeof(T).Name;

                // Obtém as propriedades da entidade
                PropertyInfo[] properties = typeof(T).GetProperties();

                // Cria a parte do comando SQL correspondente aos nomes das colunas
                string columnNames = string.Join(", ", properties.Select(p => p.Name));

                // Cria a parte do comando SQL correspondente aos valores dos parâmetros
                string parameterNames = string.Join(", ", properties.Select(p => $"@{p.Name}"));

                // Cria o comando SQL de inserção
                command.CommandText = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";

                // Adiciona os parâmetros ao comando
                foreach (var property in properties)
                {
                    object value = property.GetValue(entity);
                    command.Parameters.AddWithValue($"@{property.Name}", value);
                }

                // Executa o comando de inserção
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public void Update<T>(T entity) where T:AbstractEntity
        {
            OpenConnection();

            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;

                // Obtém o nome da tabela com base no tipo da entidade
                string tableName = typeof(T).Name;

                // Obtém as propriedades da entidade
                PropertyInfo[] properties = typeof(T).GetProperties();

                // Cria a parte do comando SQL correspondente às atualizações
                string updateStatements = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

                // Cria o comando SQL de atualização
                command.CommandText = $"UPDATE {tableName} SET {updateStatements} WHERE <coluna_chave> = @Id"; // Substitua <coluna_chave> pelo nome da coluna chave da sua tabela

                // Adiciona os parâmetros ao comando
                foreach (var property in properties)
                {
                    object value = property.GetValue(entity);
                    command.Parameters.AddWithValue($"@{property.Name}", value);
                }

                // Executa o comando de atualização
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public void Delete<T>(T entity) where T : AbstractEntity
        {
            OpenConnection();

            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;

                // Obtém o nome da tabela com base no tipo da entidade
                string tableName = typeof(T).Name;

                // Cria o comando SQL de exclusão
                command.CommandText = $"DELETE FROM {tableName} WHERE Id = @Id";

                // Adiciona o parâmetro ao comando
                command.Parameters.AddWithValue("@Id", entity.Id); // Substitua "Id" pelo nome da coluna chave da sua tabela

                // Executa o comando de exclusão
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public List<T> Select<T>() where T:AbstractEntity
        {
            OpenConnection();

            List<T> entities = new List<T>();

            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;

                // Obtém o nome da tabela com base no tipo da entidade
                string tableName = typeof(T).Name;

                // Cria o comando SQL de seleção
                command.CommandText = $"SELECT * FROM {tableName}";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Crie uma nova instância da entidade
                        T entity = Activator.CreateInstance<T>();

                        // Preencha as propriedades da entidade com os valores do resultado da consulta
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            PropertyInfo property = typeof(T).GetProperty(reader.GetName(i));
                            if (property != null && reader[i] != DBNull.Value)
                            {
                                property.SetValue(entity, reader[i]);
                            }
                        }

                        // Adicione a entidade à lista de entidades
                        entities.Add(entity);
                    }
                }
            }

            CloseConnection();

            return entities;
        }
    }
}