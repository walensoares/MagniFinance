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
    public class GradeController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: Grade
        public ActionResult Index()
        {
            var lst = db.Grades.ToList();

            List<Business.GradesInformation> v = new List<Business.GradesInformation>();

            foreach (Grades grades in lst)
            {
                v.Add(new Business.GradesInformation
                {
                    ID = grades.ID,
                    Grade = grades.Grade,
                    Name = db.Subjects.Where(w => w.ID == grades.SubjectID).Select(s => s.Name).FirstOrDefault(),
                    Student = db.Students.Where(w => w.ID == grades.StudentID).Select(s => s.Name).FirstOrDefault(),
                });
            }

            return View(v);
        }

        public JsonResult GetStudents()
        {
            var student = db.Students.ToList();
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubjects()
        {
            var subject = db.Subjects.ToList();
            return Json(subject, JsonRequestBehavior.AllowGet);
        }

        // GET: Grade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grades grades = db.Grades.Find(id);
            if (grades == null)
            {
                return HttpNotFound();
            }
            return View(grades);
        }

        // GET: Grade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,SubjectID,Grade")] Grades grades)
        {
            if (ModelState.IsValid)
            {
                db.Grades.Add(grades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grades);
        }

        // GET: Grade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grades grades = db.Grades.Find(id);
            if (grades == null)
            {
                return HttpNotFound();
            }
            return View(grades);
        }

        // POST: Grade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,SubjectID,Grade")] Grades grades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grades);
        }

        // GET: Grade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grades grades = db.Grades.Find(id);
            if (grades == null)
            {
                return HttpNotFound();
            }
            return View(grades);
        }

        // POST: Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grades grades = db.Grades.Find(id);
            db.Grades.Remove(grades);
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
