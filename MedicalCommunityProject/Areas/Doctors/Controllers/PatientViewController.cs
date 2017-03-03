using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLLayerMedCom;
using BOLayerMedCom;
using BOLayerMedCom.ViewModels;

namespace MedicalCommunityProject.Areas.Doctors.Controllers
{
    public class PatientViewController : Controller
    {
        MediyardDBEntities1 context = new MediyardDBEntities1();
        // GET: Doctors/PatientView
        public ActionResult Index(String searchString)
        {
            
            DoctorsBL dbl = new DoctorsBL(context);
            PatientsBL pbl = new PatientsBL(context);
            Doctor LoggedInDoc = dbl.getByUN(User.Identity.Name);
            //sorting desc by PatientSince Value
            List<Patient> patientsOfThisDoc = pbl.getPatientList(LoggedInDoc.DocID).OrderByDescending(o => o.PatientSince).OrderBy(o => o.FirstName).ToList();

            ViewBag.Stag = searchString;


            if (!String.IsNullOrEmpty(searchString))
            {
                patientsOfThisDoc = patientsOfThisDoc.Where(o => o.FirstName.ToLower().Contains(searchString.ToLower()) || o.LastName.ToLower().Contains(searchString.ToLower()) || o.Contact.ToLower().Contains(searchString.ToLower()) || o.Email.Contains(searchString.ToLower())).ToList();
            }

            return View("PatientList",patientsOfThisDoc);
        }

        [HttpPost]

        public ActionResult AddPatient([Bind(Include = "FirstName,LastName,Email,ContactNo")]PatientVM pvm)
        {
            PatientsBL pbl = new PatientsBL(context);
            DoctorsBL dbl = new DoctorsBL(context);


            if (!ModelState.IsValid)
            {
                ViewBag.error = true;
                return PartialView("~/Areas/Doctors/Views/Partials/AddPatientPartial.cshtml",pvm);
            }
            else
            {

                //Patient newPatient = pvm.mapPatientDataFromVM();
                Patient p=new Patient();
                p.Email = pvm.Email;
                p.PatientSince = DateTime.Now;
                p.FirstName = pvm.FirstName;
                p.LastName = pvm.LastName;
                p.Contact = pvm.ContactNo;
                p.Doctor = dbl.getByUN(User.Identity.Name);
                p.Supervisor = dbl.getByUN(User.Identity.Name).DocID;

                pbl.insertPatient(p);
                ViewBag.dataSaved = true;


                return PartialView("~/Areas/Doctors/Views/Partials/AddPatientPartial.cshtml", pvm);
            }
        }



    }
}