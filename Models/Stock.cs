using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aruna_Bakery_WithoutEntity.Models
{
    public class Stock
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter the product category ID ")]
        public string category_id { get; set; }
        [Required(ErrorMessage = "Enter the category ")]
        public string category { get; set; }
        [Required(ErrorMessage = "Enter the sub category type ")]
        public string type { get; set; }
        [Required(ErrorMessage = "Enter the quantity ")]
        public int quantity { get; set; }
        [Required(ErrorMessage = "Enter the price ")]
        public int price { get; set; }
    }
}