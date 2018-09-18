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
    public class CampusController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: Admin/Campus
        public ActionResult Index()
        {
            var campus = db.Campus.Include(c => c.College);
            return View(campus.ToList());
        }

        // GET: Admin/Campus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // GET: Admin/Campus/Create
        public ActionResult Create()
        {
            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName");
            return View();
        }

        // POST: Admin/Campus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampusId,CollegeId,CampusName,Distance")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Campus.Add(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName", campus.CollegeId);
            return View(campus);
        }

        // GET: Admin/Campus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName", campus.CollegeId);
            return View(campus);
        }

        // POST: Admin/Campus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampusId,CollegeId,CampusName,Distance")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName", campus.CollegeId);
            return View(campus);
        }

        // GET: Admin/Campus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: Admin/Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campus campus = db.Campus.Find(id);
            db.Campus.Remove(campus);
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
