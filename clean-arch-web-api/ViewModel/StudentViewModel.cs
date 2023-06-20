using CleanArch.Domain.Entities;
using System.Text.Json.Serialization;

namespace clean_arch_web_api.ViewModel
{
    public class StudentViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int courseId { get; set; }

        public StudentViewModel()
        {

        }

        [JsonConstructor]
        public StudentViewModel(int id, string name, int courseId)
        {
            this.id = id;
            this.name = name;
            this.courseId = courseId;
        }

        public StudentViewModel(Student student)
        {
            id = student.Id;
            name = student.name;
            courseId = student.courseId;
        }

        public Student ToEntity(Student student = null)
        {
            if (student == null)
            {
                student = new Student();
            }

            student.Id = id;
            student.name = name;
            student.courseId = courseId;
            return student;
        }
    }
}
