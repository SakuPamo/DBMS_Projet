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
    public class EquipmentAllocationsController : Controller
    {
        private MACBuildersEntities db = new MACBuildersEntities();

        // GET: EquipmentAllocations
        public ActionResult Index()
        {
            var equipmentAllocations = db.EquipmentAllocations.Include(e => e.Equipment).Include(e => e.Project);
            return View(equipmentAllocations.ToList());
        }

        // GET: EquipmentAllocations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentAllocation equipmentAllocation = db.EquipmentAllocations.Find(id);
            if (equipmentAllocation == null)
            {
                return HttpNotFound();
            }
            return View(equipmentAllocation);
        }

        // GET: EquipmentAllocations/Create
        public ActionResult Create()
        {
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }

        // POST: EquipmentAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipmentID,ProjectID,Duration,Qty")] EquipmentAllocation equipmentAllocation)
        {
            if (ModelState.IsValid)
            {
                db.EquipmentAllocations.Add(equipmentAllocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", equipmentAllocation.EquipmentID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", equipmentAllocation.ProjectID);
            return View(equipmentAllocation);
        }

        // GET: EquipmentAllocations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentAllocation equipmentAllocation = db.EquipmentAllocations.Find(id);
            if (equipmentAllocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", equipmentAllocation.EquipmentID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", equipmentAllocation.ProjectID);
            return View(equipmentAllocation);
        }

        // POST: EquipmentAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipmentID,ProjectID,Duration,Qty")] EquipmentAllocation equipmentAllocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipmentAllocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", equipmentAllocation.EquipmentID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", equipmentAllocation.ProjectID);
            return View(equipmentAllocation);
        }

        // GET: EquipmentAllocations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentAllocation equipmentAllocation = db.EquipmentAllocations.Find(id);
            if (equipmentAllocation == null)
            {
                return HttpNotFound();
            }
            return View(equipmentAllocation);
        }

        // POST: EquipmentAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EquipmentAllocation equipmentAllocation = db.EquipmentAllocations.Find(id);
            db.EquipmentAllocations.Remove(equipmentAllocation);
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
