using clean_arch_web_api.Domain.Entities;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Database;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Persintence.Abstracts;

namespace clean_arch_web_api.Domain.Persintence
{
    public class StudentSubjectRepository : AbstractRepositoryDb<StudentSubject>, IRepository<StudentSubject>
    {
        public StudentSubjectRepository(IConnectionManager connection) : base(connection)
        {

        }
    }
}
