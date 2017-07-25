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
    public class ProfileController : Controller
    {
        MediyardDBEntities1 context = new MediyardDBEntities1();
        // GET: Doctors/Profile
        public ActionResult Index()
        {
            DoctorsBL dbl = new DoctorsBL(context);
            Doctor loggedInDoc = dbl.getByUN(User.Identity.Name);
            ViewBag.doctor = loggedInDoc;
            DocProfileVM profVM = dbl.docProfVMfromDoc(loggedInDoc);
            ViewBag.profile = profVM;
            
            return View("ProfileView");
        }
    }
}