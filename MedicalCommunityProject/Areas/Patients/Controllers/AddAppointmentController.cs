using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalCommunityProject.Areas.Patients.Controllers
{
    public class AddAppointmentController : Controller
    {
        
        public ActionResult Index()
        {
            return View("AddAppointment");
        }


    }
}