using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayerMedCom;
using DALayerMedCom;
using BOLayerMedCom.ViewModels;


namespace BLLayerMedCom
{
    public class DoctorsBL
    {
        UnitOfWork uw = new UnitOfWork();
        public bool doctorExists(DocUserVM doc)
        {
            
            var un = doc.userName;
            var filteredDoc = uw.DoctorRepository.Get(filter: d => d.Username.ToLower().Equals(un));
            if (filteredDoc.Count()!=0)
                return true;
            else
                return false;
           }
        
        public bool verifyDoctor(DocUserVM doc)
        {
            var un = doc.userName;
            Doctor docInstance;
            var docList = uw.DoctorRepository.Get(filter: d => d.Username.ToLower().Equals(un));

            if (doctorExists(doc))
            {
                docInstance = docList.FirstOrDefault();
                if (doc.password == docInstance.Password)
                    return true;

                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           

            
        } 


           
        
    }
}

