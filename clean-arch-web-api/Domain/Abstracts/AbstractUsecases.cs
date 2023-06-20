using CleanArch.Domain.Interfaces.Database;
using CleanArch.Domain.Interfaces.Entities;
using CleanArch.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArch.Domain.Abstracts
{
    public abstract class AbstractUsecases<T> where T : IEntity
    {
        protected readonly IRepository<T> _repository;

        public AbstractUsecases(
            IRepository<T> repository
        )
        {
            _repository = repository;
        }

        public void Create(T entity)
        {
            _repository.Add(entity);
        }

        public void Delete(T entity)
        {
            _repository.Remove(entity);
        }

        public T Get(int id)
        {
            return _repository.GetById(id);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
