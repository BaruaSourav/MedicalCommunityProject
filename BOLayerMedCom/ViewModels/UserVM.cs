using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOLayerMedCom.ViewModels
{
    public class UserVM
    {
        [Required(ErrorMessage = "User Name is required.")]
        public String userName { get; set; }
        [Required(ErrorMessage ="You must provide a password to enter the services")]
        public String password { get; set; }
        public UserVM()
        {
            userName = "";
            password = "";
        }

        public UserVM(String un,String pw)
        {
            userName = un;
            password = pw;
        }
    }
}