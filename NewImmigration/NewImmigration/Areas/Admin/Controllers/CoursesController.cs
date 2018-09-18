using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewImmigration.Areas.Admin.Models;

namespace NewImmigration.Areas.Admin.Controllers
{
    public class CoursesController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: Admin/Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Category).Include(c => c.College);
                //.Include(c => c.Country);
            return View(courses.ToList());
        }

        // GET: Admin/Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // GET: Admin/Courses/Create
        public ActionResult Create()
        {
            ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "CategoryName");
            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName");
            //ViewBag.Countryid = new SelectList(db.Countries, "Countryid", "CountryName");
            return View();
        }

        // POST: Admin/Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoursesId,Countryid,CollegeId,Categoryid,CourseName,Duration,Fee,Type")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "CategoryName", courses.Categoryid);
            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName", courses.CollegeId);
            //ViewBag.Countryid = new SelectList(db.Countries, "Countryid", "CountryName", courses.Countryid);
            return View(courses);
        }

        // GET: Admin/Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "CategoryName", courses.Categoryid);
            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName", courses.CollegeId);
            //ViewBag.Countryid = new SelectList(db.Countries, "Countryid", "CountryName", courses.Countryid);
            return View(courses);
        }

        // POST: Admin/Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoursesId,Countryid,CollegeId,Categoryid,CourseName,Duration,Fee,Type")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "CategoryName", courses.Categoryid);
            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName", courses.CollegeId);
            //ViewBag.Countryid = new SelectList(db.Countries, "Countryid", "CountryName", courses.Countryid);
            return View(courses);
        }

        // GET: Admin/Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // POST: Admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courses courses = db.Courses.Find(id);
            db.Courses.Remove(courses);
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
