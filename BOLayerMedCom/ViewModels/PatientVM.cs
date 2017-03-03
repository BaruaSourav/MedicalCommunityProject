using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOLayerMedCom.ViewModels
{
    public class PatientVM
    {
        
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public String FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public String LastName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Last Name is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format")]
        public String Email { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "A Contact Number is required.")]
        
        [MaxLength(11,ErrorMessage ="A valid mobile number contains 11 digits")]
        [MinLength(11,ErrorMessage ="A valid mobile number can not be less than 11 digits")]
        [RegularExpression("^[0-9]*", ErrorMessage = "Contact no. can not contain alphabets or symbols")]
        public String ContactNo { get; set; }


        





    }
}
