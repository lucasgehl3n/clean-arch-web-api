using CleanArch.Domain.Interfaces.Entities;

namespace CleanArch.Domain.Abstracts
{
    public abstract class AbstractEntity: IEntity
    {
        public int Id { get; set;  }
    }
}
