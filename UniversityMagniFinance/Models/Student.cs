using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMagniFinance.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string RegistrantionNumber { get; set; }
        public DateTime BirthDay { get; set; }
    }
}