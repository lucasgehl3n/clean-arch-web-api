using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Entities;

namespace clean_arch_web_api.Domain.Structures
{
    public class CourseSubjectRepresentation
    {
        public Subject? Subject { get; set; }
        public int idCourseSubject { get; set; }

        public CourseSubjectRepresentation() { }
    }
}
