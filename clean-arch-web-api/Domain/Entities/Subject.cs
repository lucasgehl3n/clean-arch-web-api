using CleanArch.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Subject: AbstractEntity
    {
        public string name { get; set; }
    }
}
