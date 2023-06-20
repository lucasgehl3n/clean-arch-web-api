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
    public class CurriculumUsecases : AbstractUsecasesDb<Curriculum>, ICurriculumUsecases
    {
        private readonly IRepository<Subject> _subjectRepository;
        public CurriculumUsecases(IRepository<Curriculum> repository, IRepository<Subject> studentRepository) : base(repository)
        {
            _subjectRepository = studentRepository;
        }

        public override List<Curriculum> GetAll()
        {
            var list = base.GetAll().OrderBy(x => x.name).ToList();
            return list;
        }
    }
}
