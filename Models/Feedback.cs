using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aruna_Bakery_WithoutEntity.Models
{
    public class Feedback
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter the valied Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Enter the valied email Address")]
        public string email { get; set; }
        [Required(ErrorMessage ="please Rate us")]
 
        public int Ratings { get; set; }
        [Required(ErrorMessage = "gave us a feedback to develop our services")]
        [StringLength(500)]
        public string Comment { get; set; }
        
    }
}