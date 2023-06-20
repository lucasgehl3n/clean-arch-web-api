using CleanArch.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Curriculum : AbstractEntity
    {
        public string name { get; set; }
        public int course_id { get; set; }
    }
}
