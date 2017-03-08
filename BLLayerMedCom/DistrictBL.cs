using DALayerMedCom;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayerMedCom
{
    public class DistrictBL
    {
        public UnitOfWork uw;
        public int TotalDistricts
        {
            get
            {
                return uw.DistrictRepository.Get().Count();
            }
        }


        public DistrictBL(DbContext context)
        {
            uw = new UnitOfWork(context);
        }
        

       






    }
}

