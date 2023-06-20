using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces.Repository
{
    internal interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetByCurriculum(int curriculumId);
        IEnumerable<Student> GetByCourse(int courseId);
    }
}
