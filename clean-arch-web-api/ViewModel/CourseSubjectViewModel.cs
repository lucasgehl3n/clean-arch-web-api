using CleanArch.Domain.Entities;
using System.Text.Json.Serialization;

namespace clean_arch_web_api.ViewModel
{
    public class CourseSubjectViewModel
    {
        public int id { get; set; }
        public int course_id { get; set; }
        public int subject_id { get; set; }

        public CourseSubjectViewModel()
        {

        }

        [JsonConstructor]
        public CourseSubjectViewModel(int id, int course_id, int subject_id)
        {
            this.id = id;
            this.course_id = course_id;
            this.subject_id = subject_id;
        }

        public CourseSubjectViewModel(CourseSubject entity)
        {
            id = entity.Id;
            course_id = entity.course_id;
            subject_id = entity.subject_id;
        }

        public CourseSubject ToEntity(CourseSubject entity = null)
        {
            if (entity == null)
            {
                entity = new CourseSubject();
            }

            entity.Id = id;
            entity.course_id = course_id;
            entity.subject_id = subject_id;
            return entity;
        }
    }
}
