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
    public class WorkerAllocationsController : Controller
    {
        private MACBuildersEntities db = new MACBuildersEntities();

        // GET: WorkerAllocations
        public ActionResult Index()
        {
            var workerAllocations = db.WorkerAllocations.Include(w => w.Employee).Include(w => w.Project);
            return View(workerAllocations.ToList());
        }

        // GET: WorkerAllocations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerAllocation workerAllocation = db.WorkerAllocations.Find(id);
            if (workerAllocation == null)
            {
                return HttpNotFound();
            }
            return View(workerAllocation);
        }

        // GET: WorkerAllocations/Create
        public ActionResult Create()
        {
            ViewBag.WorkerID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }

        // POST: WorkerAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerID,ProjectID,WorkingDays")] WorkerAllocation workerAllocation)
        {
            if (ModelState.IsValid)
            {
                db.WorkerAllocations.Add(workerAllocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkerID = new SelectList(db.Employees, "EmployeeID", "FirstName", workerAllocation.WorkerID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", workerAllocation.ProjectID);
            return View(workerAllocation);
        }

        // GET: WorkerAllocations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerAllocation workerAllocation = db.WorkerAllocations.Find(id);
            if (workerAllocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkerID = new SelectList(db.Employees, "EmployeeID", "FirstName", workerAllocation.WorkerID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", workerAllocation.ProjectID);
            return View(workerAllocation);
        }

        // POST: WorkerAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerID,ProjectID,WorkingDays")] WorkerAllocation workerAllocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workerAllocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkerID = new SelectList(db.Employees, "EmployeeID", "FirstName", workerAllocation.WorkerID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", workerAllocation.ProjectID);
            return View(workerAllocation);
        }

        // GET: WorkerAllocations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerAllocation workerAllocation = db.WorkerAllocations.Find(id);
            if (workerAllocation == null)
            {
                return HttpNotFound();
            }
            return View(workerAllocation);
        }

        // POST: WorkerAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WorkerAllocation workerAllocation = db.WorkerAllocations.Find(id);
            db.WorkerAllocations.Remove(workerAllocation);
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
