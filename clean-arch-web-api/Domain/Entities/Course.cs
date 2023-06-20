using CleanArch.Domain.Abstracts;
using CleanArch.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Course: AbstractEntity
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}
