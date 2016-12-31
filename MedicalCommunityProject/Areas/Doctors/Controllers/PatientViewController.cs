using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLLayerMedCom;
using BOLayerMedCom;

namespace MedicalCommunityProject.Areas.Doctors.Controllers
{
    public class PatientViewController : Controller
    {
        // GET: Doctors/PatientView
        public ActionResult Index()
        {
            DoctorsBL dbl = new DoctorsBL();
            PatientsBL pbl = new PatientsBL();
            Doctor LoggedInDoc = dbl.getByUN(User.Identity.Name);
            //sorting desc by PatientSince Value
            List<Patient> patientsOfThisDoc = pbl.getPatientList(LoggedInDoc.DocID).OrderByDescending(o=>o.PatientSince).ToList();


            return View("PatientList",patientsOfThisDoc);
        }
    }
}