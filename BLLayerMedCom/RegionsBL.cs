using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayerMedCom;
using System.Web.Mvc;
////////////////////////////////////////////////////
using System.Data;
using System.Data.Entity;

namespace BLLayerMedCom
{
   public class RegionsBL
    {
        public UnitOfWork uw;
        public int TotalRegions
        {
            get
            {
                return uw.RegionRepository.Get().Count();
            }
        }

        public RegionsBL(DbContext context)
        {
            uw = new UnitOfWork(context);
        }



        public SelectList getRegionList()
        {
            return new SelectList(uw.RegionRepository.Get(), "RegionID", "RegionName");

        }

    }
}
