using clean_arch_web_api.Domain.Exceptions;
using clean_arch_web_api.Domain.Persintence;
using clean_arch_web_api.Domain.Structures;
using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Domain.Interfaces.Usecases;
using CleanArch.Persintence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Usecases
{
    public class CourseSubjectUsecases : AbstractUsecasesDb<CourseSubject>, ICourseSubjectUsecases
    {
        private readonly IRepository<CourseSubject> _courseSubjectRepository;
        private readonly IRepository<Subject> _subjectRepository;
        public CourseSubjectUsecases(IRepository<CourseSubject> repository, IRepository<Subject> courseRepository) : base(repository)
        {
            _courseSubjectRepository = repository;
            _subjectRepository = courseRepository;
        }

        public List<CourseSubjectRepresentation> GetAllSubjects(int idCourse)
        {
            var listCourseSubject = _courseSubjectRepository.GetByProperty("course_id", idCourse.ToString()).ToList();
            var listSubjects = listCourseSubject.Select(x =>
            {

                return new CourseSubjectRepresentation()
                {
                    Subject = _subjectRepository.GetById(x.subject_id),
                    idCourseSubject = x.Id,
                };
            }).ToList();

            return listSubjects;
        }

        public void ValidateDelete(CourseSubject entity)
        {
            var listCourseSubject = _courseSubjectRepository.GetByProperty("course_id", entity.course_id.ToString()).ToList();
            if ((listCourseSubject?.Count() ?? 0) < 10)
            {
                throw new BusinessRule("Um Curso deve ter, no mínimo, dez disciplinas. Adicione outras para removê-la");
            }
        }
    }
}