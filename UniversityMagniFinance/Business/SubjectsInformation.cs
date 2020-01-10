using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMagniFinance.Models;

namespace UniversityMagniFinance.Business
{
    public class SubjectsInformation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public decimal? AverageGrade { get; set; }
    }
}