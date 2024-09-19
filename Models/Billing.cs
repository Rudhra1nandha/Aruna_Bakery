using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Aruna_Bakery_WithoutEntity.Models
{
    public class Billing
    {
        public int id { get; set; }
        public long customer_number { get; set; }
        public string product_id { get; set; }
        [DataType(DataType.Date)]
        public string bill_date { get; set; }
        public decimal gst { get; set; }
        public decimal discount { get; set; }
        public int total_payment { get; set; }

    }
}