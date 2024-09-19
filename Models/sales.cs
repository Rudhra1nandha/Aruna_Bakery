using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aruna_Bakery_WithoutEntity.Models
{
    public class sales
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter the customer Number ")]
        public long customerNumber { get; set; }
        [Required(ErrorMessage = "Enter the ProductId ")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Enter the PurchaseDate ")]
        [DataType(DataType.Date)]
        public string PurchaseDate { get; set; }
        [Required(ErrorMessage = "Enter the quantity ")]
        public int quantity { get; set; }
        [Required(ErrorMessage = "Enter the payment ")]
        public string payment { get; set; }
        [Required(ErrorMessage = "Enter the price ")]
        public int price { get; set; }

    }
}