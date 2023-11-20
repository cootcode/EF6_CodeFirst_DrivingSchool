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
    public class CustomersController : Controller
    {
        private DrivingSchoolDbContext db = new DrivingSchoolDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Address).Include(c => c.Ref_Customer_Status);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "StreetName");
            ViewBag.CustomerStatusCode = new SelectList(db.Ref_Customer_Statuses, "CustomerStatusCode", "CustomerStatusDescription");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,DateBecameCustomer,DateOfBirth,FirstName,LastName,AmountOutstanding,Email,PhoneNumber,CellMobilePhoneNumber,OtherCustomerDetails,AddressId,CustomerStatusCode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "StreetName", customer.AddressId);
            ViewBag.CustomerStatusCode = new SelectList(db.Ref_Customer_Statuses, "CustomerStatusCode", "CustomerStatusDescription", customer.CustomerStatusCode);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "StreetName", customer.AddressId);
            ViewBag.CustomerStatusCode = new SelectList(db.Ref_Customer_Statuses, "CustomerStatusCode", "CustomerStatusDescription", customer.CustomerStatusCode);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,DateBecameCustomer,DateOfBirth,FirstName,LastName,AmountOutstanding,Email,PhoneNumber,CellMobilePhoneNumber,OtherCustomerDetails,AddressId,CustomerStatusCode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "StreetName", customer.AddressId);
            ViewBag.CustomerStatusCode = new SelectList(db.Ref_Customer_Statuses, "CustomerStatusCode", "CustomerStatusDescription", customer.CustomerStatusCode);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
