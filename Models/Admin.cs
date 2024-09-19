using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aruna_Bakery_WithoutEntity.Models
{
    public class Admin
    {
        public int id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string cpassword { get; set; }
            
        
    }
}