using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBMSProjet.Database;

namespace DBMSProjet.Controllers
{
    public class JobRatesController : Controller
    {
        private MACBuildersEntities db = new MACBuildersEntities();

        // GET: JobRates
        public ActionResult Index()
        {
            return View(db.JobRates.ToList());
        }

        // GET: JobRates/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRate jobRate = db.JobRates.Find(id);
            if (jobRate == null)
            {
                return HttpNotFound();
            }
            return View(jobRate);
        }

        // GET: JobRates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobTitle,Rate")] JobRate jobRate)
        {
            if (ModelState.IsValid)
            {
                db.JobRates.Add(jobRate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobRate);
        }

        // GET: JobRates/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRate jobRate = db.JobRates.Find(id);
            if (jobRate == null)
            {
                return HttpNotFound();
            }
            return View(jobRate);
        }

        // POST: JobRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobTitle,Rate")] JobRate jobRate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobRate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobRate);
        }

        // GET: JobRates/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRate jobRate = db.JobRates.Find(id);
            if (jobRate == null)
            {
                return HttpNotFound();
            }
            return View(jobRate);
        }

        // POST: JobRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            JobRate jobRate = db.JobRates.Find(id);
            db.JobRates.Remove(jobRate);
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
