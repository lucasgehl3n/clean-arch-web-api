using clean_arch_web_api.Domain.Persintence.Abstracts;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Database;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Persintence.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persintence
{
    public class StudentRepository : RepositoryDbManager<Student>, IRepository<Student>, IStudentRepository
    {
        public StudentRepository(IConnectionManager connection) : base(connection)
        {

        }

        public IEnumerable<Student> GetByCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetByCurriculum(int curriculumId)
        {
            throw new NotImplementedException();
        }
    }
}
