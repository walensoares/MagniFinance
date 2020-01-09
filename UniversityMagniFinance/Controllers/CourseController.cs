using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityMagniFinance.DAL;
using UniversityMagniFinance.Models;

namespace UniversityMagniFinance.Controllers
{
    public class CourseController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: Course
        public ActionResult Index()
        {
            var lst = db.Courses.ToList();
            List<Business.CoursesInformation> v = new List<Business.CoursesInformation>();

            foreach (Course course in lst)
            {
                int students = db.Grades.Join(db.Subjects, g => g.SubjectID,
                                s => s.ID,
                                (g, s) => new { Grades = g, Subjects = s }).Where(y => y.Subjects.CourseID == course.ID).Select(s => s.Grades.StudentID).Distinct().Count();  

                decimal? sum = db.Grades.Join(db.Subjects, g => g.SubjectID,
                                s => s.ID,
                                (g, s) => new { Grades = g, Subjects = s }).Where(y => y.Subjects.CourseID == course.ID).Select(s => s.Grades.Grade).Sum();

                int grades = db.Grades.Join(db.Subjects, g => g.SubjectID,
                                s => s.ID,
                                (g, s) => new { Grades = g, Subjects = s }).Where(y => y.Subjects.CourseID == course.ID && y.Grades.Grade != null).Select(s => s.Grades.ID).Count();

                decimal? average = 0;

                if (sum != null && grades > 0)
                {
                    average = sum / grades;
                }

                v.Add(new Business.CoursesInformation { 
                    ID = course.ID, 
                    Name = course.Name, 
                    QTeachers = db.Subjects.Where(y => y.CourseID == course.ID).Select(s => s.TeacherID).Distinct().Count(),
                    QStudents = students,
                    AverageGrade = average
                });
            };
            return View(v);
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
