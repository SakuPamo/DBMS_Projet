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
    public class ProjectPaymentsController : Controller
    {
        private MACBuildersEntities db = new MACBuildersEntities();

        // GET: ProjectPayments
        public ActionResult Index()
        {
            var projectPayments = db.ProjectPayments.Include(p => p.Project);
            return View(projectPayments.ToList());
        }

        // GET: ProjectPayments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPayment projectPayment = db.ProjectPayments.Find(id);
            if (projectPayment == null)
            {
                return HttpNotFound();
            }
            return View(projectPayment);
        }

        // GET: ProjectPayments/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }

        // POST: ProjectPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,PaymentType,Amount,PaymentDate,InvoiceNo")] ProjectPayment projectPayment)
        {
            if (ModelState.IsValid)
            {
                db.ProjectPayments.Add(projectPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectPayment.ProjectID);
            return View(projectPayment);
        }

        // GET: ProjectPayments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPayment projectPayment = db.ProjectPayments.Find(id);
            if (projectPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectPayment.ProjectID);
            return View(projectPayment);
        }

        // POST: ProjectPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,PaymentType,Amount,PaymentDate,InvoiceNo")] ProjectPayment projectPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectPayment.ProjectID);
            return View(projectPayment);
        }

        // GET: ProjectPayments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPayment projectPayment = db.ProjectPayments.Find(id);
            if (projectPayment == null)
            {
                return HttpNotFound();
            }
            return View(projectPayment);
        }

        // POST: ProjectPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProjectPayment projectPayment = db.ProjectPayments.Find(id);
            db.ProjectPayments.Remove(projectPayment);
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
