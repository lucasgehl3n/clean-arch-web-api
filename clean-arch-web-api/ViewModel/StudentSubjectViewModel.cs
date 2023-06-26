using clean_arch_web_api.Domain.Entities;
using CleanArch.Domain.Entities;
using System.Text.Json.Serialization;

namespace clean_arch_web_api.ViewModel
{
    public class StudentSubjectViewModel
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public int subject_id { get; set; }

        public StudentSubjectViewModel()
        {

        }

        [JsonConstructor]
        public StudentSubjectViewModel(int id, int student_id, int subject_id)
        {
            this.id = id;
            this.student_id = student_id;
            this.subject_id = subject_id;
        }

        public StudentSubjectViewModel(StudentSubject entity)
        {
            id = entity.Id;
            student_id = entity.student_id;
            subject_id = entity.subject_id;
        }

        public StudentSubject ToEntity(StudentSubject entity = null)
        {
            if (entity == null)
            {
                entity = new StudentSubject();
            }

            entity.Id = id;
            entity.student_id = student_id;
            entity.subject_id = subject_id;
            return entity;
        }
    }
}
