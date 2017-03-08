using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BOLayerMedCom;
using BLLayerMedCom;

namespace MedicalCommunityProject.Areas.Admins.Controllers
{
    public class AdminDashController : Controller
    {
        //as a field initializer can not refer to a non static member
        private static MediyardDBEntities1 context = new MediyardDBEntities1();
        DoctorsBL dbl = new DoctorsBL(context);
        PatientsBL pbl = new PatientsBL(context);
        AdminBL abl = new AdminBL(context);
        DistrictBL disbl = new DistrictBL(context);
        RegionsBL rbl = new RegionsBL(context);

        // GET: Admin/AdminDash
        [Authorize]
        public ActionResult Index()
        {
            
            ViewBag.docCount = dbl.TotalDoctors;
            ViewBag.patCount = pbl.TotalPatients;
            ViewBag.regionCount = rbl.TotalRegions;
            ViewBag.districtCount = disbl.TotalDistricts;
            ViewBag.adminCount = abl.TotalAdmins;

            return View("AdminDash");
        }




        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Global" });
        }
    }
}