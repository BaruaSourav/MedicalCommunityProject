using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOLayerMedCom.ViewModels;
using BLLayerMedCom;
using BOLayerMedCom;
using System.Web.Security;

namespace MedicalCommunityProject.Areas.Doctors.Controllers
{
    public class DoctorController : Controller
    {
        public DoctorController()
        {
            ViewBag.RegSuccess = null;
            ViewBag.WrongPW = null;
            ViewBag.NoUser = null;
        }
        // GET: Doctors/Doctor
        public ActionResult Index()
        {
            return View("DocHome");
        }
        //[HttpGet]
        //public ActionResult Login()
        //{
        //    return View("DocLoginWindow");
        //}

        [HttpPost]
        
        public ActionResult Login(UserVM doc) // recieves the doctor's viewmodel
        {
            if (ModelState.IsValid)
            {
                DoctorsBL dbl = new DoctorsBL();
                if (dbl.doctorExists(doc))
                {
                    if (dbl.verifyDoctor(doc))
                    {
                        FormsAuthentication.SetAuthCookie(doc.userName, false);
                        return View("DoctorDash");
                    }
                    else
                    {
                        ViewBag.WrongPW = true;   
                        return View("~/Areas/Global/Views/Home/Home.cshtml");
                    }
                }

                ViewBag.NoUser = true;

                return View("~/Areas/Global/Views/Home/Home.cshtml");
            }
            else
                return View("~/Areas/Global/Views/Home/Home.cshtml");
        }
        [HttpGet]

        public ActionResult Register()
        {
            RegionsBL rbl = new RegionsBL();
            ViewData["RegionID"] = rbl.getRegionList();
            return View("Register");
        }
        [HttpPost]
        

        public ActionResult Register([Bind(Include = "DocID,Address,FirstName,LastName,UserName,DOB,Email,RegionID,Password")] Doctor doc)

        {
            DoctorsBL dbl = new DoctorsBL();
            RegionsBL rbl = new RegionsBL();
            doc.isOnline = false;
            doc.isActive = false;
            doc.TariffCode = String.Empty;

            if (ModelState.IsValid)
            {
                dbl.insertDoc(doc);
                ViewBag.RegSuccess = true;
                return View("~/Areas/Global/Views/Home/Home.cshtml");
            }

            ViewData["RegionID"] = rbl.getRegionList();
            return View("Register");
        }

        public ActionResult ViewPatients()
        {

            return Content("test");
        }





        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return View("~/Areas/Global/Views/Home/Home.cshtml");
        }
    }
}