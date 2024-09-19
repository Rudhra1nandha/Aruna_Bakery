using Aruna_Bakery_WithoutEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;


namespace Aruna_Bakery_WithoutEntity.Controllers
{
    public class Stock_detailsController : Controller
    {
        string constr = WebConfigurationManager.ConnectionStrings["Aruna_bakery"].ConnectionString;

        // GET: Stock_details
        public ActionResult Index()
        {
            List<Stock> Stock_list_obj = new List<Stock>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Sp_Stock", con);
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Stock_list_obj.Add(new Stock()
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        category_id = sdr["category_id"].ToString(),
                        category = sdr["category"].ToString(),
                        type = sdr["type"].ToString(),
                        quantity = Convert.ToInt32(sdr["quantity"]),
                        price = Convert.ToInt32(sdr["price"]),
                    });
                con.Close();
            }
            return View(Stock_list_obj);
        }

        // GET: Stock_details/Details/5
        public ActionResult Details(int id)
        {
            Stock Stock_list_obj = new Stock();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "Sp_Stock_details " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Stock_list_obj = new Stock
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        category_id = sdr["category_id"].ToString(),
                        category = sdr["category"].ToString(),
                        type = sdr["type"].ToString(),
                        quantity = Convert.ToInt32(sdr["quantity"]),
                        price = Convert.ToInt32(sdr["price"]),
                    };
                con.Close();
            }
            return View(Stock_list_obj);

        }

        // GET: Stock_details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stock_details/Create
        [HttpPost]
        public ActionResult Create(Stock Stock_list_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr)) 
                {
                    string query = "Sp_Stock_insert '"+ Stock_list_obj.category_id + "','"+
                       Stock_list_obj.category+"','"+ Stock_list_obj.type+"',"+ Stock_list_obj.quantity+
                       ","+ Stock_list_obj.price;
                    SqlCommand cmd = new SqlCommand(query,con);
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

        // GET: Stock_details/Edit/5
        public ActionResult Edit(int id)
        {
            Stock Stock_list_obj = new Stock();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "Sp_Stock_details " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Stock_list_obj = new Stock
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        category_id = sdr["category_id"].ToString(),
                        category = sdr["category"].ToString(),
                        type = sdr["type"].ToString(),
                        quantity = Convert.ToInt32(sdr["quantity"]),
                        price = Convert.ToInt32(sdr["price"]),
                    };
                con.Close();
            }
            return View(Stock_list_obj);

        }

        // POST: Stock_details/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Stock Stock_list_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "Sp_Stock_update " + id + ",'" + Stock_list_obj.category_id + "','" + Stock_list_obj.category +
                        "','" + Stock_list_obj.type + "',"
                        + Stock_list_obj.quantity + "," + Stock_list_obj.price;
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

        // GET: Stock_details/Delete/5
        public ActionResult Delete(int id)
        {
            Stock Stock_list_obj = new Stock();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "Sp_Stock_details " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Stock_list_obj = new Stock
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        category_id = sdr["category_id"].ToString(),
                        category = sdr["category"].ToString(),
                        type = sdr["type"].ToString(),
                        quantity = Convert.ToInt32(sdr["quantity"]),
                        price = Convert.ToInt32(sdr["price"]),
                    };
                con.Close();
            }
            return View(Stock_list_obj);

        }

        // POST: Stock_details/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Stock Stock_list_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "Sp_Stock_delete " + id;
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
