using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOLayerMedCom.ViewModels;

namespace MedicalCommunityProject.Areas.Global.Controllers
{
    public class HomeController : Controller
    {
        // GET: Global/Home
        public ActionResult Index()
        {
            return View("Home");
        }
        
        
        public ActionResult AdminLogin()
        {
            return  PartialView( "~/Areas/Global/Views/Partials/AdminLoginPartial.cshtml");
            
        }

        [HttpPost]
        public ActionResult AdminLogin([Bind(Include = "userName,password")]UserVM uvm)
        {
            return PartialView("~/Areas/Global/Views/Partials/AdminLoginPartial.cshtml");

        }





    }
}