﻿using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces.Usecases
{
    public interface IRegistrationUsecases : IEntityUsecases<Registration>
    {
        List<Registration> GetByStudent(int studentId);
        List<Registration> GetBySubject(int subjectId);
    }
}
