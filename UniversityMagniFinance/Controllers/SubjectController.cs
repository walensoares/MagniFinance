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
    public class SubjectController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: Subject
        public ActionResult Index()
        {
            var lst = db.Subjects.ToList();

            List<Business.SubjectsInformation> v = new List<Business.SubjectsInformation>();

            foreach (Subject subject in lst)
            {
                int grades = db.Grades.Where(w => w.SubjectID == subject.ID).Select(s => s.ID).Count();

                decimal? sum = db.Grades.Where(w => w.SubjectID == subject.ID).Select(s => s.Grade).Sum();

                decimal? average = 0;

                if (sum != null && grades > 0)
                {
                    average = sum / grades;
                }

                v.Add(new Business.SubjectsInformation
                {
                    ID = subject.ID,
                    Name = subject.Name,
                    Teacher = db.Teachers.Find(subject.TeacherID),
                    AverageGrade = average
                });
            }

            return View(v);
        }

        public JsonResult GetTeachers()
        {
            var teacher = db.Teachers.ToList();
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourses()
        {
            var teacher = db.Courses.ToList();
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        // GET: Subject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CourseID,TeacherID")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CourseID,TeacherID")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
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
