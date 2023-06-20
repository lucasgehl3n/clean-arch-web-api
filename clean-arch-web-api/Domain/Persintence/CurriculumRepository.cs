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
    public class CurriculumRepository : AbstractRepositoryDb<Curriculum>, IRepository<Curriculum>, ICurriculumRepository
    {
        public CurriculumRepository(IConnectionManager connection) : base(connection)
        {

        }
    }
}
