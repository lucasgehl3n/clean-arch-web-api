using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Interfaces.Repository;

namespace clean_arch_web_api.Domain.Interfaces.Repository
{
    public interface IAbstractRepositoryDb<ImplementedClass> : IRepository<ImplementedClass> where ImplementedClass : AbstractEntity
    {
    }
}
