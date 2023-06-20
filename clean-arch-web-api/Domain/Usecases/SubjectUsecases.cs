using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Domain.Interfaces.Usecases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Usecases
{
    public class SubjectUsecases : AbstractUsecasesDb<Subject>, ISubjectUsecases
    {
        public SubjectUsecases(IRepository<Subject> repository) : base(repository)
        {
        }

        public List<Subject> GetByCurriculum(int curriculumId)
        {
            return _repository.GetAll().ToList();
        }
    }
}
