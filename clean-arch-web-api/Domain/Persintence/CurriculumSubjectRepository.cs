using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Database;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Persintence.Abstracts;

namespace CleanArch.Persintence
{
    public class CourseSubjectRepository : AbstractRepositoryDb<CourseSubject>, IRepository<CourseSubject>
    {
        public CourseSubjectRepository(IConnectionManager connection) : base(connection)
        {

        }
    }
}
