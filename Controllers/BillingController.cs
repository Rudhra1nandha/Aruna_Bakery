using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Aruna_Bakery_WithoutEntity.Models;
using System.Web.Configuration;
using System.Xml;


namespace Aruna_Bakery_WithoutEntity.Controllers
{
    public class BillingController : Controller
    {
        string constr = WebConfigurationManager.ConnectionStrings["Aruna_bakery"].ConnectionString;
        // GET: Billing
        public ActionResult Index()
        {
            List<Billing> Billing_List = new List<Billing>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("billing_data", con);
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Billing_List.Add(new Billing()
                    {
                        id = Convert.ToInt32(sdr[0]),
                        customer_number = Convert.ToInt64(sdr[1]),
                        product_id = Convert.ToString(sdr[2]),
                        bill_date = Convert.ToString(sdr[3]),
                        gst = Convert.ToInt32(sdr[4]),
                        discount = Convert.ToInt32(sdr[5]),
                        total_payment = Convert.ToInt32(sdr[6]),
                    });
                con.Close();
            }
            return View(Billing_List);

        }

        // GET: Billing/Details/5
        public ActionResult Details(int id)
        {
            Billing Billing_List = new Billing();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("billing_data_id "+id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Billing_List = new Billing
                    {
                        id = Convert.ToInt32(sdr[0]),
                        customer_number = Convert.ToInt64(sdr[1]),
                        product_id = Convert.ToString(sdr[2]),
                        bill_date = Convert.ToString(sdr[3]),
                        gst = Convert.ToInt32(sdr[4]),
                        discount = Convert.ToInt32(sdr[5]),
                        total_payment = Convert.ToInt32(sdr[6]),
                    };
                con.Close();
            }
            return View(Billing_List);
        }

        // GET: Billing/Create
        public ActionResult Create()
        {
                return View();
        }
      

        // POST: Billing/Create
        [HttpPost]
        public ActionResult Create(Billing Billing_List)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "create_new_bill " + Billing_List.customer_number + ",'" +
                        Billing_List.product_id +
                       "','" + Billing_List.@bill_date + "'," + Billing_List.@gst + "," +
                        Billing_List.@discount + "," + Billing_List.total_payment;
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Billing/Edit/5
        public ActionResult Edit(int id)
        {
            Billing Billing_List = new Billing();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("billing_data_id " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Billing_List = new Billing
                    {
                        id = Convert.ToInt32(sdr[0]),
                        customer_number = Convert.ToInt64(sdr[1]),
                        product_id = Convert.ToString(sdr[2]),
                        bill_date = Convert.ToString(sdr[3]),
                        gst = Convert.ToInt32(sdr[4]),
                        discount = Convert.ToInt32(sdr[5]),
                        total_payment = Convert.ToInt32(sdr[6]),
                    };
                con.Close();
            }
            return View(Billing_List);
        }

        // POST: Billing/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Billing Billing_List)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "update_billind_data " +id+","+ Billing_List.customer_number + ",'" +
                        Billing_List.product_id +
                       "','" + Billing_List.@bill_date + "'," + Billing_List.@gst + "," +
                        Billing_List.@discount + "," + Billing_List.total_payment;
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Billing/Delete/5
        public ActionResult Delete(int id)
        {
            Billing Billing_List = new Billing();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("billing_data_id " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Billing_List = new Billing
                    {
                        id = Convert.ToInt32(sdr[0]),
                        customer_number = Convert.ToInt64(sdr[1]),
                        product_id = Convert.ToString(sdr[2]),
                        bill_date = Convert.ToString(sdr[3]),
                        gst = Convert.ToInt32(sdr[4]),
                        discount = Convert.ToInt32(sdr[5]),
                        total_payment = Convert.ToInt32(sdr[6]),
                    };
                con.Close();
            }
            return View(Billing_List);
        }

        // POST: Billing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Billing Billing_List)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "clear_billind_data " + id ;
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
