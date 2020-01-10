using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMagniFinance.Models;

namespace UniversityMagniFinance.Business
{
    public class StudentsInformation
    {
        public Student Student { get; set; }
        public List<GradesInformation> GradesInformation { get; set; }
    }
}