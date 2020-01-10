using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMagniFinance.Business
{
    public class GradesInformation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? Grade { get; set; }
        public string Student { get; set; }
    }
}