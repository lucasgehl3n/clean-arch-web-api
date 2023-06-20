using clean_arch_web_api.Domain.Structures;
using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Database;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Domain.Interfaces.Usecases;
using CleanArch.Persintence;
using CleanArch.Persintence.Abstracts;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Usecases
{
    public class CourseUsecases : AbstractUsecasesDb<Course>, ICourseUsecases
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<CourseSubject> _courseSubjectRepository;
        private readonly IRepository<Subject> _subjectRepository;
        public CourseUsecases(
            IRepository<Course> courseRepository, IRepository<CourseSubject> courseSubjectRepository, IRepository<Subject> subjectRepository) : base(courseRepository)
        {
            _courseRepository = courseRepository;
            _courseSubjectRepository = courseSubjectRepository;
            _subjectRepository = subjectRepository;
        }

        public override List<Course> GetAll()
        {
            var list = base.GetAll().OrderBy(x => x.name).ToList();
            return list;
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
    }
}
