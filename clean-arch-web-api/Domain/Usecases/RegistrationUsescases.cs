using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces.Usecases
{
    public class RegistrationUsecases : AbstractUsecases<Registration>, IRegistrationUsecases
    {
        private readonly IRegistrationRepository _convertedRepository;
        public RegistrationUsecases(IRegistrationRepository repository) : base(repository)
        {
            _convertedRepository = repository;
        }

        public List<Registration> GetByStudent(int studentId)
        {
            return _convertedRepository.GetByStudent(studentId).ToList();
        }

        public List<Registration> GetBySubject(int subjectId)
        {
            return _convertedRepository.GetBySubject(subjectId).ToList();
        }

        public void Save(Registration entity)
        {
            throw new NotImplementedException();
        }
    }
}
