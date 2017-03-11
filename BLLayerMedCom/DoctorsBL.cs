using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayerMedCom;
using DALayerMedCom;
using BOLayerMedCom.ViewModels;
using System.Web.Security;
using System.Data.Entity;

namespace BLLayerMedCom
{
    public class DoctorsBL
    {
        public UnitOfWork uw;
        //read-only count for Doctors Entity 
        public int TotalDoctors {
            get
            {
                return uw.DoctorRepository.Get().Count();
            }
        }


        public DoctorsBL(DbContext context)
        {
            uw = new UnitOfWork(context);
        }
        public bool doctorExists(UserVM doc)
        {
            
            var un = doc.userName;
            var filteredDoc = uw.DoctorRepository.Get(filter: d => d.Username.ToLower().Equals(un));
            if (filteredDoc.Count()!=0)
                return true;
            else
                return false;
           }
        
        public bool verifyDoctor(UserVM doc)
        {
            var un = doc.userName;
            Doctor docInstance;
            var docList = uw.DoctorRepository.Get(filter: d => d.Username.ToLower().Equals(un));

            if (doctorExists(doc))
            {
                docInstance = docList.FirstOrDefault();
                if (doc.password == docInstance.Password)
                {
                    System.Diagnostics.Trace.WriteLine("verifydoc- Login Success");

                    //FormsAuthentication.SetAuthCookie(docInstance.Username,false);
                    return true;
                }
                else
                {
                     System.Diagnostics.Trace.WriteLine("verifydoc- Login Failed");
                    return false;
                }
            }
            else
            {
                return false;
            }
           

            
        } 

        public bool insertDoc(Doctor doc)
        {
            uw.DoctorRepository.Insert(doc);
            uw.Save();
            return false;
        }


        public Doctor getByUN(string un)
        {
            var v = uw.DoctorRepository.Get(filter: o => o.Username.Equals(un));
            return v.First<Doctor>();
        }
        public void setOnline(string un)
        {
            Doctor doc = uw.DoctorRepository.Get(filter: o => o.Username.Equals(un)).FirstOrDefault();
            doc.isOnline = true;
            uw.DoctorRepository.Update(doc);
            uw.Save();
        }
        public void setOffline(string un)
        {
            Doctor doc = uw.DoctorRepository.Get(filter: o => o.Username.Equals(un)).FirstOrDefault();
            doc.isOnline = false;
            uw.DoctorRepository.Update(doc);
            uw.Save();
        }



    }
}

