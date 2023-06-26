using CleanArch.Domain.Entities;

namespace clean_arch_web_api.Domain.Structures
{
    public class StudentSubjectRepresentation
    {
        public Subject? Subject { get; set; }
        public int idStudentSubject { get; set; }

        public StudentSubjectRepresentation() { }
    }
}
