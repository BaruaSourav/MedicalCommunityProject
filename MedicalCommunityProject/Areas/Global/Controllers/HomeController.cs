using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOLayerMedCom.ViewModels;
using BLLayerMedCom;
using BOLayerMedCom;
using System.Web.Security;

namespace MedicalCommunityProject.Areas.Global.Controllers
{
    public class HomeController : Controller
    {
        // GET: Global/Home

        MediyardDBEntities1 context = new MediyardDBEntities1();
        public ActionResult Index()
        {
            return View("Home");
        }
        
        
        public ActionResult AdminLogin()
        {
            return  PartialView( "~/Areas/Global/Views/Partials/AdminLoginPartial.cshtml");
            
        }

        [HttpPost]
        public ActionResult AdminLogin([Bind(Include = "userName,password")]UserVM adm)
        {
            
            if (ModelState.IsValid)
            {
                AdminBL abl = new AdminBL(context);
                if (abl.adminExists(adm))
                {
                    if (abl.verifyAdmin(adm))
                    {
                        FormsAuthentication.SetAuthCookie(adm.userName, false);

                        //return RedirectToAction("Index","AdminDash",new { area = "Admin" });
                        return JavaScript("window.location='" + Url.Action("Index", "AdminDash", new { area = "Admins" }) + "'");
                    }

                    else
                    {
                        ViewBag.WrongPW = true;
                        return PartialView("~/Areas/Global/Views/Partials/AdminLoginPartial.cshtml");
                    }
                }
                ViewBag.NoUser = true;


            }

            return PartialView("~/Areas/Global/Views/Partials/AdminLoginPartial.cshtml");

        }





    }
}