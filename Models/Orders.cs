using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Aruna_Bakery_WithoutEntity.Models
{
    public class Orders
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter the Order Id ")]
        public string order_id { get; set; }
        [Required(ErrorMessage = "Enter the Customer Name ")]
        public string customer_name { get; set; }
        [Required(ErrorMessage = "Enter the Item Name ")]
        public string Item_name { get; set; }
        [Required(ErrorMessage = "Enter the Quantity ")]
        public int quantity { get; set; }
        [Required(ErrorMessage = "Enter the Delivery Date ")]
        [DataType(DataType.Date)]
        public string delivery_date { get; set; }
    }
}