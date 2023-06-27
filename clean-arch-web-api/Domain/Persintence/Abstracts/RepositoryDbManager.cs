using clean_arch_web_api.Domain.Interfaces.Repository;
using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Interfaces.Database;
using CleanArch.Persintence.Abstracts;
using static CleanArch.Domain.Database.ConnectionGenerate;

namespace clean_arch_web_api.Domain.Persintence.Abstracts
{
    public class RepositoryDbManager<ImplementedClass> where ImplementedClass : AbstractEntity
    {
        private IAbstractRepositoryDb<ImplementedClass> _repository;
        private IConnectionManager _connection;
        public RepositoryDbManager(IConnectionManager connection)
        {
            _connection = connection;
            SetDataBaseRepository(_connection.GetDatabaseType());
        }

        public void SetDataBaseRepository(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.PostgreSQL:
                    _repository = new AbstractRepositoryDbPostgre<ImplementedClass>(_connection);
                    break;
                case DatabaseType.MySql:
                    _repository = new AbstractRepositoryDbMySQL<ImplementedClass>(_connection);
                    break;
                default:
                    throw new ArgumentException("Necessário informar um banco de dados válido");
            }
        }

        public IEnumerable<ImplementedClass> GetAll()
        {
            return _repository.GetAll();
        }

        public ImplementedClass GetById(int id){
            return _repository.GetById(id);
        }

        public IEnumerable<ImplementedClass> GetByProperty(string propertyName, string propertyValue)
        {
            return _repository.GetByProperty(propertyName, propertyValue);
        }

        public void Add(ImplementedClass entity){
            _repository.Add(entity);
        }

        public void Update(ImplementedClass entity){
            _repository.Update(entity);
        }

        public void Remove(ImplementedClass entity){
            _repository.Remove(entity);
        }
    }
}
