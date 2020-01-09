using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using UniversityMagniFinance.Models;

namespace UniversityMagniFinance.DAL
{
    public class UniversityInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            var students = new List<Student>
            {
                new Student{Name="Walen Almeida Soares",ID=1,BirthDay=DateTime.Parse("1990-03-12"),RegistrantionNumber="000001"},
                new Student{Name="Stefani Trombini",ID=2,BirthDay=DateTime.Parse("1995-04-30"),RegistrantionNumber="000002"},
                new Student{Name="Allejo Brasil",ID=3,BirthDay=DateTime.Parse("1994-11-15"),RegistrantionNumber="000003"}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var course = new List<Course>
            {
                new Course{ID=1,Name="Análise de Sistemas"},
                new Course{ID=2,Name="Administração"}
            };

            course.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var teacher = new List<Teacher>
            {
                new Teacher{ID=1,Name="Carlos Alberto",BirthDay=DateTime.Parse("1960-01-01"),Salary=10000},
                new Teacher{ID=2,Name="Darcy Gonçalves Soares",BirthDay=DateTime.Parse("1975-02-28"),Salary=11000}
            };

            teacher.ForEach(t => context.Teachers.Add(t));
            context.SaveChanges();

            var subject = new List<Subject>
            {
                new Subject{ID=1,Name="Economia",CourseID=2,TeacherID=1},
                new Subject{ID=2,Name="Hardware",CourseID=1,TeacherID=2}
            };

            subject.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            var grades = new List<Grades>
            {
                new Grades{ID=1,Grade=9,StudentID=1,SubjectID=2},
                new Grades{ID=2,Grade=10,StudentID=2,SubjectID=1},
                new Grades{ID=3,Grade=7,StudentID=3,SubjectID=2}
            };

            grades.ForEach(g => context.Grades.Add(g));
            context.SaveChanges();
        }
    }
}