using CleanArch.Domain.Abstracts;
namespace CleanArch.Domain.Entities
{
    public class CourseSubject : AbstractEntity
    {
        public int course_id { get; set; }
        public int subject_id { get; set; }
    }
}
