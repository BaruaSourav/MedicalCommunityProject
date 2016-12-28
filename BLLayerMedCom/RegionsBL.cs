using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayerMedCom;
using System.Web.Mvc;

using System.Data;

namespace BLLayerMedCom
{
   public class RegionsBL
    {
        UnitOfWork uw = new UnitOfWork();
        public SelectList getRegionList()
        {
            return new SelectList(uw.RegionRepository.Get(), "RegionID", "RegionName");

        }

    }
}
