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
    public class StudentUsecases : AbstractUsecasesDb<Student>, IStudentUsecases
    {
        private readonly IRepository<Subject> _subjectRepository;

        public StudentUsecases(IRepository<Student> repository, IRepository<Subject> subjectRepository) : base(repository)
        {
            _subjectRepository = subjectRepository;
        }


        public override List<Student> GetAll()
        {
            var list = base.GetAll().OrderBy(x => x.name).ToList();
            return list;
        }

        public void AddSubject(Student student, Subject subject)
        {
            //student.Subjects.Add(subject);
            //subject.Students.Add(student);
            _repository.Update(student);
            _subjectRepository.Update(subject);
        }
    }
}
