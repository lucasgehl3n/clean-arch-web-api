using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces.Repository
{
    public interface IRegistrationRepository :  IRepository<Registration> 
    {
        IEnumerable<Registration> GetByStudent(int studentId);
        IEnumerable<Registration> GetBySubject(int subjectId);
    }
}
