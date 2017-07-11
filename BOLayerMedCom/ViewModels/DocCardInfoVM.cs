using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLayerMedCom.ViewModels
{
    public class DocCardInfoVM
    {
        [Key]
        public int id { get; set; }

        public String Name { get; set; }
        public int Fees { get; set; }
        public bool isOnline { get; set; }
        public String PracticingAddress { get; set; }
        public int totalPatients { get; set; }
        public String spec { get; set; }


        //public Region region
        //{
        //    //Need to Change ----- 
        //    get; set;
        //}
        //public String district{

        //    get
        //    {
        //        return region.District.DistrictName;
        //    }
            

        //}



    }
}
