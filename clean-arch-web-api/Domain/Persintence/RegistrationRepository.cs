using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Persintence.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persintence
{
    public class RegistrationRepository : AbstractRepository<Registration>, IRegistrationRepository
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Subject> _subjectRepository;
        public RegistrationRepository(IRepository<Student> studentRepository, IRepository<Subject> subjectRepository)
        {
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }

        public new void Add(Registration entity)
        {
            base.Add(entity);

            var student = _studentRepository.GetById(entity.StudentId);
            var subject = _subjectRepository.GetById(entity.SubjectId);
            
           // student.Subjects.Add(subject);
            //subject.Students.Add(student);

            _studentRepository.Update(student);
            _subjectRepository.Update(subject);
        }

        public new void Remove(Registration entity)
        {
            base.Remove(entity);

            var student = _studentRepository.GetById(entity.StudentId);
            var subject = _subjectRepository.GetById(entity.SubjectId);
            
            //student.Subjects.Remove(subject);
            //ubject.Students.Remove(student);

            _studentRepository.Update(student);
            _subjectRepository.Update(subject);
        }

        public new void Update(Registration entity)
        {
            base.Update(entity);
            var student = _studentRepository.GetById(entity.StudentId);
            var subject = _subjectRepository.GetById(entity.SubjectId);

            // var studentIndex = student.Subjects.FindIndex(x => x == subject);
            
            // if (studentIndex > 0)
            // {
            //     student.Subjects.RemoveAt(studentIndex);
            //     student.Subjects.Insert(studentIndex, subject);
            // }
        }

        public IEnumerable<Registration> GetByStudent(int studentId)
        {
            return this.entityList.Where(x => x.StudentId == studentId);
        }

        public IEnumerable<Registration> GetBySubject(int subjectId)
        {
            return this.entityList.Where(x => x.SubjectId == subjectId);
        }
    }
}

