using clean_arch_web_api.Domain.Persintence.Abstracts;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Database;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Persintence.Abstracts;

namespace CleanArch.Persintence
{
    public class CourseSubjectRepository : RepositoryDbManager<CourseSubject>, IRepository<CourseSubject>
    {
        public CourseSubjectRepository(IConnectionManager connection) : base(connection)
        {

        }
    }
}
