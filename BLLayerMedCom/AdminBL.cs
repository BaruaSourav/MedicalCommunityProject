using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayerMedCom;
using System.Data.Entity;
using BOLayerMedCom;
using BOLayerMedCom.ViewModels;

namespace BLLayerMedCom
{
    public class AdminBL
    {
        public UnitOfWork uw;
        public int TotalAdmins
        {
            get
            {
                return uw.AdminRepository.Get().Count();
            }
        }

        public AdminBL(DbContext context)
        {
            uw = new UnitOfWork(context);
        }
        //function returning bool decision if admin exists
        public bool adminExists(UserVM admin)
        {

            var un = admin.userName;
            var filteredAdmin = uw.AdminRepository.Get(filter: d => d.userName.ToLower().Equals(un));
            if (filteredAdmin.Count() != 0)
                return true;
            else
                return false;
        }
        public bool verifyAdmin(UserVM adm)
        {
            var un = adm.userName;
            Admin admInstance;
            var admList = uw.AdminRepository.Get(filter: d => d.userName.ToLower().Equals(un));

            if (adminExists(adm))
            {
                admInstance = admList.FirstOrDefault();
                if (adm.password == admInstance.password)
                {
                    System.Diagnostics.Trace.WriteLine("Personal Log- verifyAdmin- Login Success");

                    //FormsAuthentication.SetAuthCookie(docInstance.Username,false);
                    return true;
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("Personal Log -verifyAdmin- Login Failed");
                    return false;
                }
            }
            else
            {
                return false;
            }



        }


        public bool insertAdm(Admin adm)
        {
            uw.AdminRepository.Insert(adm);
            uw.Save();
            return false;
        }


        public Admin getByUN(string un)
        {
            var v = uw.AdminRepository.Get(filter: o => o.userName.Equals(un));
            return v.First<Admin>();
        }




    }
}
