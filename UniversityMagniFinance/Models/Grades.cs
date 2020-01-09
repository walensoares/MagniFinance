using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMagniFinance.Models
{
    public class Grades
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public decimal? Grade { get; set; }
    }
}