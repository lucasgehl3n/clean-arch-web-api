using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces.Usecases
{
    public interface IEntityUsecases<T> where T: IEntity
    {
        void Save(T entity);
        T Get(int id);
        void Delete(T entity);
        List<T> GetAll();
    }
}
