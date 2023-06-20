using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Entities;
using CleanArch.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persintence.Abstracts
{
    public abstract class AbstractRepository<ImplementedClass> : IRepository<ImplementedClass> where ImplementedClass: AbstractEntity
    {
        public AbstractRepository()
        {

        }

        protected List<ImplementedClass> entityList { get; set; } = new List<ImplementedClass>();
        public void Add(ImplementedClass entity)
        {
            if(entity.Id == 0)
            {
                entity.Id = entityList.Count() + 1;
            }

            this.entityList.Add(entity);
        }

        public IEnumerable<ImplementedClass> GetAll()
        {
            return entityList;
        }

        public ImplementedClass GetById(int id)
        {
            return entityList.FirstOrDefault(ImplementedClass => ImplementedClass.Id == id);
        }

        public IEnumerable<ImplementedClass> GetByProperty(string propertyName, string propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Remove(ImplementedClass entity)
        {
            this.entityList = this.entityList.Where(ImplementedClass => ImplementedClass.Id != entity.Id).ToList();
        }

        public void Update(ImplementedClass entity)
        {
            var currentCourse = this.entityList.FindIndex(ImplementedClass => ImplementedClass.Id == entity.Id);
            if (currentCourse > 0)
            {
                this.entityList.RemoveAt(currentCourse);
                this.entityList.Insert(currentCourse, entity);
            }
        }
    }
}
