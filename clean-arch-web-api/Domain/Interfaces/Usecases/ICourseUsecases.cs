﻿using clean_arch_web_api.Domain.Structures;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces.Usecases
{
    public interface ICourseUsecases : IEntityUsecases<Course>
    {
        List<CourseSubjectRepresentation> GetAllSubjects(int idCourse);
    }
}
