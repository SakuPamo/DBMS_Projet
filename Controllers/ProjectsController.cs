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
    public class ProjectsController : Controller
    {
        private MACBuildersEntities db = new MACBuildersEntities();

        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.Client1).Include(p => p.Employee).Include(p => p.Employee1);
            return View(projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.Client = new SelectList(db.Clients, "ClientID", "FirstName");
            ViewBag.ProjectConsultant = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.ProjectManager = new SelectList(db.Employees, "EmployeeID", "FirstName");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,ProjectName,BusinessName,Location,StartDate,EndDate,ServiceCharge,ConsultantFee,PersonnelCost,ProjectConsultant,ProjectManager,Client")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Client = new SelectList(db.Clients, "ClientID", "FirstName", project.Client);
            ViewBag.ProjectConsultant = new SelectList(db.Employees, "EmployeeID", "FirstName", project.ProjectConsultant);
            ViewBag.ProjectManager = new SelectList(db.Employees, "EmployeeID", "FirstName", project.ProjectManager);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client = new SelectList(db.Clients, "ClientID", "FirstName", project.Client);
            ViewBag.ProjectConsultant = new SelectList(db.Employees, "EmployeeID", "FirstName", project.ProjectConsultant);
            ViewBag.ProjectManager = new SelectList(db.Employees, "EmployeeID", "FirstName", project.ProjectManager);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,ProjectName,BusinessName,Location,StartDate,EndDate,ServiceCharge,ConsultantFee,PersonnelCost,ProjectConsultant,ProjectManager,Client")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client = new SelectList(db.Clients, "ClientID", "FirstName", project.Client);
            ViewBag.ProjectConsultant = new SelectList(db.Employees, "EmployeeID", "FirstName", project.ProjectConsultant);
            ViewBag.ProjectManager = new SelectList(db.Employees, "EmployeeID", "FirstName", project.ProjectManager);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
