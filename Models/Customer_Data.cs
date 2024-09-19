using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aruna_Bakery_WithoutEntity.Models
{
    public class Customer_Data
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the unique  Customers Id")]
        public string Customer_Id { get; set; }
        [Required(ErrorMessage = "Enter the Customers Name")]
        public string Customer_Name { get; set; }
        [Required(ErrorMessage = "Enter the Customers Number")]
        public long Phone_Number { get; set; }
        [Required(ErrorMessage = "Enter the Customers location")]
        public string Location { get; set; }

    }
}