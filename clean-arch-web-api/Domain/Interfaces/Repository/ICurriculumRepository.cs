using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces.Repository
{
    public interface ICurriculumRepository : IRepository<Curriculum>
    {
        //IEnumerable<Curriculum> GetByCourse(int courseId);
    }
}
