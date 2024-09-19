using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;
using Aruna_Bakery_WithoutEntity.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Aruna_Bakery_WithoutEntity.Controllers
{
    public class OrdersController : Controller
    {
        string constr = WebConfigurationManager.ConnectionStrings["Aruna_bakery"].ConnectionString;
        // GET: Orders
        public ActionResult Index()
        {
            if ((string)Session["Employeename"] == null)
            {
                return RedirectToAction("Sign_in", "Signin");
            }
            else
            {
                ViewBag.LoggedinuserEmp = Session["Employeename"];
                List<Orders> order_obj = new List<Orders>();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("orders_info", con);
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                        order_obj.Add(new Orders
                        {
                            id = Convert.ToInt32(sdr[0]),
                            order_id = sdr[1].ToString(),
                            customer_name = sdr[2].ToString(),
                            Item_name = sdr[3].ToString(),
                            quantity = Convert.ToInt32(sdr[4]),
                            delivery_date = sdr[5].ToString()
                        });
                }
                return View(order_obj);
            }
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            Orders order_obj = new Orders();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("order_info_id "+id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    order_obj = new Orders
                    {
                        id = Convert.ToInt32(sdr[0]),
                        order_id = sdr[1].ToString(),
                        customer_name = sdr[2].ToString(),
                        Item_name = sdr[3].ToString(),
                        quantity = Convert.ToInt32(sdr[4]),
                        delivery_date = sdr[5].ToString()
                    };
            }
            return View(order_obj);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(Orders order_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr)) 
                {
                    string query = "Sp_new_order '"+ order_obj.order_id+"','"+ order_obj.customer_name+
                       "','" +order_obj.Item_name+"',"+ order_obj.quantity +",'"+
                        order_obj.delivery_date+"'";
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

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            Orders order_obj = new Orders();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("order_info_id " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    order_obj = new Orders
                    {
                        id = Convert.ToInt32(sdr[0]),
                        order_id = sdr[1].ToString(),
                        customer_name = sdr[2].ToString(),
                        Item_name = sdr[3].ToString(),
                        quantity = Convert.ToInt32(sdr[4]),
                        delivery_date = sdr[5].ToString()
                    };
            }
            return View(order_obj);

        }

        // POST: Orders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Orders order_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "edit_order " +id+",'"+ order_obj.order_id + "','" + order_obj.customer_name +
                       "','" + order_obj.Item_name + "'," + order_obj.quantity + ",'" +
                        order_obj.delivery_date + "'";
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            Orders order_obj = new Orders();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("order_info_id " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    order_obj = new Orders
                    {
                        id = Convert.ToInt32(sdr[0]),
                        order_id = sdr[1].ToString(),
                        customer_name = sdr[2].ToString(),
                        Item_name = sdr[3].ToString(),
                        quantity = Convert.ToInt32(sdr[4]),
                        delivery_date = sdr[5].ToString()
                    };
            }
            return View(order_obj);

        }

        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Orders order_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "clear_order " + id ;
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

        public ActionResult Logout()
        {
            Session["AdminName"] = null;
            Session["Employeename"] = null;

            return RedirectToAction("Index", "Orders");
        }
    }
}
