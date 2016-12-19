using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalCommunityProject.Areas.Doctors
{
    public class DocLoginController : Controller
    {
        // GET: Doctors/DocLogin
        public ActionResult Index()
        {
            return View("DocLoginWIndow");
        }
    }
}