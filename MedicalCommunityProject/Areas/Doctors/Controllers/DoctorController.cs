using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOLayerMedCom.ViewModels;
using BLLayerMedCom;

namespace MedicalCommunityProject.Areas.Doctors.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctors/Doctor
        public ActionResult Index()
        {
            return View("DocHome");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View("DocLoginWindow");
        }

        [HttpPost]
        public ActionResult Login(DocUserVM doc) // recieves the doctor's viewmodel
        {
            DoctorsBL dbl = new DoctorsBL();
            if (dbl.doctorExists(doc))
            {
                if (dbl.verifyDoctor(doc))
                {
                    return Content("<html><h1>Success</h1></html>");
                }
                else
                    return Content("<html><h1>Login Failed</h1></html>");
            }



            return Content("<html><h1>No User Found</h1></html>"); ;
        }


    }
}