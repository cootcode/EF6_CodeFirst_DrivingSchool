using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EF6_CodeFirst_DrivingSchool.Models;

namespace EF6_CodeFirst_DrivingSchool.Controllers
{
    public class LessonsController : Controller
    {
        private DrivingSchoolDbContext db = new DrivingSchoolDbContext();

        // GET: Lessons
        public ActionResult Index()
        {
            var lessons = db.Lessons.Include(l => l.Customer).Include(l => l.Ref_Lesson_Status).Include(l => l.Staff).Include(l => l.Vehicle);
            return View(lessons.ToList());
        }

        // GET: Lessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // GET: Lessons/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName");
            ViewBag.LessonStatusCode = new SelectList(db.Ref_Lesson_Statuses, "LessonStatusCode", "LessonStatusDescription");
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "Nickname");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "VehicleDetails");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LessonId,LessonDate,LessonTime,Price,OtherLessonDetails,StaffId,CustomerId,VehicleId,LessonStatusCode")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(lesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", lesson.CustomerId);
            ViewBag.LessonStatusCode = new SelectList(db.Ref_Lesson_Statuses, "LessonStatusCode", "LessonStatusDescription", lesson.LessonStatusCode);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "Nickname", lesson.StaffId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "VehicleDetails", lesson.VehicleId);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", lesson.CustomerId);
            ViewBag.LessonStatusCode = new SelectList(db.Ref_Lesson_Statuses, "LessonStatusCode", "LessonStatusDescription", lesson.LessonStatusCode);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "Nickname", lesson.StaffId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "VehicleDetails", lesson.VehicleId);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LessonId,LessonDate,LessonTime,Price,OtherLessonDetails,StaffId,CustomerId,VehicleId,LessonStatusCode")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", lesson.CustomerId);
            ViewBag.LessonStatusCode = new SelectList(db.Ref_Lesson_Statuses, "LessonStatusCode", "LessonStatusDescription", lesson.LessonStatusCode);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "Nickname", lesson.StaffId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "VehicleDetails", lesson.VehicleId);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            db.Lessons.Remove(lesson);
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
