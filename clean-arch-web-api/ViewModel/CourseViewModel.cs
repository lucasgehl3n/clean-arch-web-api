using CleanArch.Domain.Entities;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace clean_arch_web_api.ViewModel
{
    public class CourseViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public CourseViewModel()
        {
         
        }

        [JsonConstructor]
        public CourseViewModel(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public CourseViewModel(Course course) {
            id = course.Id;
            name = course.name;
            description = course.description;
        }

        public Course ToEntity(Course course = null)
        {
            if(course == null)
            {
                course = new Course();
            }

            course.Id = id; 
            course.name = name;
            course.description = description;
            return course;
        }
    }
}
