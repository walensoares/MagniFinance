﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMagniFinance.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CourseID { get; set; }
        public int TeacherID { get; set; }
    }
}