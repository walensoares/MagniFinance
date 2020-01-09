using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMagniFinance.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public decimal Salary { get; set; }
    }
}