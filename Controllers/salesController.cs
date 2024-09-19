using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Aruna_Bakery_WithoutEntity.Models;

namespace Aruna_Bakery_WithoutEntity.Controllers
{
    public class salesController : Controller
    {
        string constr = WebConfigurationManager.ConnectionStrings["Aruna_bakery"].ConnectionString;

        // GET: sales
        public ActionResult Index()
        {
            List<sales> sales_obj = new List<sales>();
            using (SqlConnection con  = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("salesInfo", con);
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    sales_obj.Add(new sales
                    {
                        id = Convert.ToInt32(sdr[0]),
                        customerNumber = Convert.ToInt64(sdr[1]),
                        ProductId = Convert.ToString(sdr[2]),
                        PurchaseDate = Convert.ToString(sdr[3]),
                        quantity = Convert.ToInt32(sdr[4]),
                        payment = Convert.ToString(sdr[5]),
                        price = Convert.ToInt32(sdr[6])
                    });
                
            }
                return View(sales_obj);
        }

        // GET: sales/Details/5
        public ActionResult Details(int id)
        {
            sales sales_obj = new sales();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sales_particular_id " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    sales_obj = new sales
                    {
                        id = Convert.ToInt32(sdr[0]),
                        customerNumber = Convert.ToInt64(sdr[1]),
                        ProductId = Convert.ToString(sdr[2]),
                        PurchaseDate = Convert.ToString(sdr[3]),
                        quantity = Convert.ToInt32(sdr[4]),
                        payment = Convert.ToString(sdr[5]),
                        price = Convert.ToInt32(sdr[6])
                    };

            }
            return View(sales_obj);
        }

        // GET: sales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sales/Create
        [HttpPost]
        public ActionResult Create(sales sales_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "newsalesInfo " + sales_obj.customerNumber + ",'" +
                       sales_obj.ProductId + "','" + sales_obj.PurchaseDate +
                       "'," + sales_obj.quantity + ",'" + sales_obj.payment + 
                       "'," + sales_obj.price;
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

        // GET: sales/Edit/5
        public ActionResult Edit(int id)
        {
            sales sales_obj = new sales();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sales_particular_id " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    sales_obj = new sales
                    {
                        id = Convert.ToInt32(sdr[0]),
                        customerNumber = Convert.ToInt64(sdr[1]),
                        ProductId = Convert.ToString(sdr[2]),
                        PurchaseDate = Convert.ToString(sdr[3]),
                        quantity = Convert.ToInt32(sdr[4]),
                        payment = Convert.ToString(sdr[5]),
                        price = Convert.ToInt32(sdr[6])
                    };

            }
            return View(sales_obj);
        }

        // POST: sales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, sales sales_obj)
        {
            
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "update_sales "+id +","+ sales_obj.customerNumber + ",'" +
                       sales_obj.ProductId + "','" + sales_obj.PurchaseDate +
                       "'," + sales_obj.quantity + ",'" + sales_obj.payment +
                       "'," + sales_obj.price;
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

        // GET: sales/Delete/5
        public ActionResult Delete(int id)
        {
            sales sales_obj = new sales();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sales_particular_id " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    sales_obj = new sales
                    {
                        id = Convert.ToInt32(sdr[0]),
                        customerNumber = Convert.ToInt64(sdr[1]),
                        ProductId = Convert.ToString(sdr[2]),
                        PurchaseDate = Convert.ToString(sdr[3]),
                        quantity = Convert.ToInt32(sdr[4]),
                        payment = Convert.ToString(sdr[5]),
                        price = Convert.ToInt32(sdr[6])
                    };

            }
            return View(sales_obj);
        }

        // POST: sales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, sales sales_obj)
        {
            
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "clear_sale " + id;
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
