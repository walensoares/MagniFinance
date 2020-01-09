using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMagniFinance.Business
{
    public class CoursesInformation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int QTeachers { get; set; }
        public int QStudents { get; set; }
        public decimal? AverageGrade { get; set; }
    }
}