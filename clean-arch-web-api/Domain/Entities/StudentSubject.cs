using CleanArch.Domain.Abstracts;

namespace clean_arch_web_api.Domain.Entities
{
    public class StudentSubject : AbstractEntity
    {
        public int subject_id { get; set; }
        public int student_id { get; set; }
    }
}
