using clean_arch_web_api.Domain.Entities;
using clean_arch_web_api.Domain.Exceptions;
using clean_arch_web_api.Domain.Interfaces.Usecases;
using clean_arch_web_api.Domain.Structures;
using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Domain.Interfaces.Usecases;
using CleanArch.Persintence;

namespace clean_arch_web_api.Domain.Usecases
{
    public class StudentSubjectUsecases : AbstractUsecasesDb<StudentSubject>, IStudentSubjectUsecases
    {

        private readonly IRepository<StudentSubject> _studentSubjectRepository;
        private readonly IRepository<Subject> _subjectRepository;

        public StudentSubjectUsecases(IRepository<StudentSubject> repository, IRepository<Subject> subjectRepository) : base(repository)
        {
            _studentSubjectRepository = repository;
            _subjectRepository = subjectRepository;
        }

        public List<StudentSubjectRepresentation> GetAllSubjects(int idStudent)
        {
            var listCourseSubject = _studentSubjectRepository.GetByProperty("student_id", idStudent.ToString()).ToList();
            var listSubjects = listCourseSubject.Select(x =>
            {

                return new StudentSubjectRepresentation()
                {
                    Subject = _subjectRepository.GetById(x.subject_id),
                    idStudentSubject = x.Id,
                };
            }).ToList();

            return listSubjects;
        }

        public void ValidateDelete(StudentSubject entity)
        {
            var listStudentSubject = _studentSubjectRepository.GetByProperty("student_id", entity.student_id.ToString()).ToList();
            if ((listStudentSubject?.Count() ?? 0) < 3)
            {
                throw new BusinessRule("Um Aluno deve ter, no mínimo, três disciplinas. Adicione outras para removê-la");
            }
        }
    }
}
