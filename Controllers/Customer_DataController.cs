using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Aruna_Bakery_WithoutEntity.Models;
using System.Web.Configuration;

namespace Aruna_Bakery_WithoutEntity.Controllers
{
    public class Customer_DataController : Controller
    {
        string constr = WebConfigurationManager.ConnectionStrings["Aruna_bakery"].ConnectionString;

        // GET: Customer_Data
        public ActionResult Index()
        {
            List< Customer_Data> Customer_data_obj = new List<Customer_Data>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("CustomerInfo", con);
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Customer_data_obj.Add(new Customer_Data()
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        Customer_Id = sdr["Customer_Id"].ToString(),
                        Customer_Name = Convert.ToString(sdr["Customer_Name"]),
                        Phone_Number = Convert.ToInt64(sdr["Phone_Number"]),
                        Location = sdr["Location"].ToString()
                    });
                con.Close();
            }
                return View(Customer_data_obj);
        }

        // GET: Customer_Data/Details/5
        public ActionResult Details(int id)
        {
            Customer_Data Customer_data_obj = new Customer_Data();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "CustomerInfo_Id " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Customer_data_obj = new Customer_Data
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        Customer_Id = sdr["Customer_Id"].ToString(),
                        Customer_Name = sdr["Customer_Name"].ToString(),
                        Phone_Number = Convert.ToInt64(sdr["Phone_Number"]),
                        Location = sdr["Location"].ToString()
                    };
                con.Close();
            }
            return View(Customer_data_obj);
        }

        // GET: Customer_Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer_Data/Create
        [HttpPost]
        public ActionResult Create(Customer_Data Customer_data_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr)) 
                {
                    string query = "New_Customer '" + Customer_data_obj.Customer_Id + "','" +
                        Customer_data_obj.Customer_Name + "'," + Customer_data_obj.Phone_Number + ",'" +
                        Customer_data_obj.Location + "'";
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

        // GET: Customer_Data/Edit/5
        public ActionResult Edit(int id)
        {
            Customer_Data Customer_data_obj = new Customer_Data();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "CustomerInfo_Id " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Customer_data_obj = new Customer_Data
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        Customer_Id = sdr["Customer_Id"].ToString(),
                        Customer_Name = sdr["Customer_Name"].ToString(),
                        Phone_Number = Convert.ToInt64(sdr["Phone_Number"]),
                        Location = sdr["Location"].ToString()
                    };
                con.Close();
            }
            return View(Customer_data_obj);
        }

        // POST: Customer_Data/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer_Data Customer_data_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "update_customer_detail " + id +",'"+
                        Customer_data_obj.Customer_Id + "','" +
                        Customer_data_obj.Customer_Name + "'," + Customer_data_obj.Phone_Number + ",'" +
                        Customer_data_obj.Location + "'";
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

        // GET: Customer_Data/Delete/5
        public ActionResult Delete(int id)
        {
            Customer_Data Customer_data_obj = new Customer_Data();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "CustomerInfo_Id " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Customer_data_obj = new Customer_Data
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        Customer_Id = sdr["Customer_Id"].ToString(),
                        Customer_Name = sdr["Customer_Name"].ToString(),
                        Phone_Number = Convert.ToInt64(sdr["Phone_Number"]),
                        Location = sdr["Location"].ToString()
                    };
                con.Close();
            }
            return View(Customer_data_obj);
        }

        // POST: Customer_Data/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer_Data Customer_data_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "CustomerInfo_delete " + id;
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
