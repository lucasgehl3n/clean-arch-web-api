using CleanArch.Domain.Entities;
using System.Text.Json.Serialization;

namespace clean_arch_web_api.ViewModel
{
    public class SubjectViewModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public SubjectViewModel()
        {

        }

        [JsonConstructor]
        public SubjectViewModel(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public SubjectViewModel(Subject entity)
        {
            id = entity.Id;
            name = entity.name;
        }

        public Subject ToEntity(Subject entity = null)
        {
            if (entity == null)
            {
                entity = new Subject();
            }

            entity.Id = id;
            entity.name = name;
            return entity;
        }
    }
}
