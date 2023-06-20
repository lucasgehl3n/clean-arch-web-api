using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByProperty(string propertyName, string propertyValue);
    }
}
