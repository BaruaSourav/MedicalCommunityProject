using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalCommunityProject.Areas.Global.Controllers
{
    public class HomeController : Controller
    {
        // GET: Global/Home
        public ActionResult Index()
        {
            return View("Home");
        }

    }
}