using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Domain.Interfaces.Usecases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Usecases
{
    public class CurriculumSubjectUsecases : AbstractUsecasesDb<CourseSubject>, ICourseSubjectUsecases
    {
        public CurriculumSubjectUsecases(IRepository<CourseSubject> repository) : base(repository)
        {
            
        }
    }
}