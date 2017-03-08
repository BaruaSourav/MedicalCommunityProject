using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOLayerMedCom;

namespace MedicalCommunityProject.Areas.Admins.Controllers
{
    public class PatientListController : Controller
    {
        private MediyardDBEntities1 db = new MediyardDBEntities1();

        // GET: Admins/PatientList
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Doctor);
            return View(patients.ToList());
        }

        // GET: Admins/PatientList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Admins/PatientList/Create
        public ActionResult Create()
        {
            ViewBag.Supervisor = new SelectList(db.Doctors, "DocID", "Address");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,FirstName,LastName,Email,Contact,Supervisor,PatientSince")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Supervisor = new SelectList(db.Doctors, "DocID", "Address", patient.Supervisor);
            return View(patient);
        }

        // GET: Admins/PatientList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Supervisor = new SelectList(db.Doctors, "DocID", "Address", patient.Supervisor);
            return View(patient);
        }

        // POST: Admins/PatientList/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,FirstName,LastName,Email,Contact,Supervisor,PatientSince")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Supervisor = new SelectList(db.Doctors, "DocID", "Address", patient.Supervisor);
            return View(patient);
        }

        // GET: Admins/PatientList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Admins/PatientList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
