using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOLayerMedCom;
using BLLayerMedCom;
using BOLayerMedCom.ViewModels;
namespace MedicalCommunityProject.Areas.Patients.Controllers
{
    public class AppointmentController : Controller
    {
        public MediyardDBEntities1 context = new MediyardDBEntities1();
        // GET: Patients/Appointment


        public ActionResult Index(String sortby = null, String searchText = null,int? spec=null)
        {
           
            DoctorsBL dbl= new DoctorsBL(context);
            List<Specialization> specList = context.Specializations.ToList();
            List<String> sortbylist =
            new List<String>
            {
                "Consultation Fees",
                "Doctor's Name",
                "Number of Patients"
            };

            SelectList sblist = new SelectList(sortbylist);



            var doclist = dbl.getAll();


            //List<DocCardInfoVM> dcardinfovm;

            if (Request.IsAjaxRequest())
            {

                return PartialView("DocListPartial.cshtml");
            }
            else
            {

                ViewBag.sortbylist = sblist;
                ViewBag.specList = specList;
                ViewBag.dcardinfovm = (IEnumerable<DocCardInfoVM>)dbl.getDocCardList(doclist);
                return View("DoctorsList");
            }



            
        }
        [HttpGet]
        public ActionResult DoctorInfo(int id)
        {
            Session["appDocID"] = id;
            DoctorsBL dbl=new DoctorsBL(context);
            DocCardInfoVM model = dbl.docVMfromDoc(context.Doctors.Find(id));

            return View(model);
        }


        public ActionResult PatientVerify()
        {

            return View();
        }


    }
}