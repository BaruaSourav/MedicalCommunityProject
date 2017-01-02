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
        
        [Display(Name ="First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public String FirstName;
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public String LastName;
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Last Name is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format")]
        public String Email;
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "A contact Number is required.")]
        [MaxLength(11)]
        [MinLength(1)]
        [RegularExpression("[^0-9]", ErrorMessage = "Contact no. can not contain alphabets or symbols")]
        public String ContactNo;








    }
}
