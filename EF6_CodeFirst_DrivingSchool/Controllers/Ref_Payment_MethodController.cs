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
    public class Ref_Payment_MethodController : Controller
    {
        private DrivingSchoolDbContext db = new DrivingSchoolDbContext();

        // GET: Ref_Payment_Method
        public ActionResult Index()
        {
            return View(db.Ref_Payment_Methods.ToList());
        }

        // GET: Ref_Payment_Method/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Payment_Method ref_Payment_Method = db.Ref_Payment_Methods.Find(id);
            if (ref_Payment_Method == null)
            {
                return HttpNotFound();
            }
            return View(ref_Payment_Method);
        }

        // GET: Ref_Payment_Method/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ref_Payment_Method/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentMethodCode,PaymentMethodDescription")] Ref_Payment_Method ref_Payment_Method)
        {
            if (ModelState.IsValid)
            {
                db.Ref_Payment_Methods.Add(ref_Payment_Method);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_Payment_Method);
        }

        // GET: Ref_Payment_Method/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Payment_Method ref_Payment_Method = db.Ref_Payment_Methods.Find(id);
            if (ref_Payment_Method == null)
            {
                return HttpNotFound();
            }
            return View(ref_Payment_Method);
        }

        // POST: Ref_Payment_Method/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentMethodCode,PaymentMethodDescription")] Ref_Payment_Method ref_Payment_Method)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Payment_Method).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ref_Payment_Method);
        }

        // GET: Ref_Payment_Method/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Payment_Method ref_Payment_Method = db.Ref_Payment_Methods.Find(id);
            if (ref_Payment_Method == null)
            {
                return HttpNotFound();
            }
            return View(ref_Payment_Method);
        }

        // POST: Ref_Payment_Method/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ref_Payment_Method ref_Payment_Method = db.Ref_Payment_Methods.Find(id);
            db.Ref_Payment_Methods.Remove(ref_Payment_Method);
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
