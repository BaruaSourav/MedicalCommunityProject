using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOLayerMedCom.ViewModels
{
    public class DocUserVM
    {
        public String userName { get; set; }
        public String password { get; set; }
        public DocUserVM()
        {
            userName = "";
            password = "";
        }

        public DocUserVM(String un,String pw)
        {
            userName = un;
            password = pw;
        }
    }
}