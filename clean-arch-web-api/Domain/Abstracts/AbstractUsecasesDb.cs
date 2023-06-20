using CleanArch.Domain.Interfaces.Database;
using CleanArch.Domain.Interfaces.Entities;
using CleanArch.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArch.Domain.Abstracts
{
    public abstract class AbstractUsecasesDb<T> where T : AbstractEntity
    {
        protected readonly IRepository<T> _repository;

        public AbstractUsecasesDb(
            IRepository<T> repository
        )
        {
            _repository = repository;
        }

        public void Save(T entity)
        {
            if (entity.Id == 0)
            {
                _repository.Add(entity);
            }
            else
            {
                _repository.Update(entity);
            }
        }

        public void Delete(T entity)
        {
            _repository.Remove(entity);
        }

        public T Get(int id)
        {
            return _repository.GetById(id);
        }

        public virtual List<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }
    }
}
