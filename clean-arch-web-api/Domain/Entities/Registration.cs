using CleanArch.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Registration: AbstractEntity
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
