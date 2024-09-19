using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aruna_Bakery_WithoutEntity.Models
{
    public class Login
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter the  Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the  user Id")]
        public string user_id { get; set; }
        [Required(ErrorMessage ="Enter the phone number")]
       
        public long phone_no { get; set; }
        [Required(ErrorMessage = "Enter the place ")]
        public string place { get; set; }
        [Required(ErrorMessage = "Enter the gender ")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Enter the email ")]
        public string email { get; set; }
        [Required(ErrorMessage = "Enter the password ")]
        public string password { get; set; }
        [Required(ErrorMessage = "Enter the cpassword ")]

        public string cpassword { get; set; }
    }
}