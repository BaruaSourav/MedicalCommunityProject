using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayerMedCom;
using DALayerMedCom;
using BOLayerMedCom.ViewModels;
using System.Web.Security;

namespace BLLayerMedCom
{
    public class DoctorsBL
    {
        UnitOfWork uw = new UnitOfWork();
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

                    FormsAuthentication.SetAuthCookie(docInstance.Username,false);
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

           
        
    }
}

