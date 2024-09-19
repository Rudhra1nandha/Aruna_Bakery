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
    public class AdminController : Controller
    {
        string constr = WebConfigurationManager.ConnectionStrings["Aruna_bakery"].ConnectionString;
        // GET: Admin
        public ActionResult Index()
        {
            if ((string)Session["AdminName"] == null)
            {
                return RedirectToAction("Sign_in", "Signin");
            }
            else
            {

                ViewBag.Loggedinuser = Session["AdminName"];
                List<Admin> Admin_obj = new List<Admin>();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("Admin_info", con);
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                        Admin_obj.Add(new Admin()
                        {
                            id = Convert.ToInt32(sdr[0]),
                            name = (sdr[1]).ToString(),
                            email = Convert.ToString(sdr[2]),
                            password = Convert.ToString(sdr[3]),
                            cpassword = (sdr[4]).ToString()
                        });
                    con.Close();
                }
                return View(Admin_obj);
            }
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            Admin Admin_obj = new Admin();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Admin_detail " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Admin_obj = new Admin
                    {
                        id = Convert.ToInt32(sdr[0]),
                        name = (sdr[1]).ToString(),
                        email = Convert.ToString(sdr[2]),
                        password = Convert.ToString(sdr[3]),
                        cpassword = (sdr[4]).ToString()
                    };
                con.Close();
            }
            return View(Admin_obj);

        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Admin Admin_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "new_Admin '" + Admin_obj.name + "','" +
                        Admin_obj.email +
                       "','" + Admin_obj.password + "','" + Admin_obj.cpassword +"'";
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            Admin Admin_obj = new Admin();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Admin_detail " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Admin_obj = new Admin
                    {
                        id = Convert.ToInt32(sdr[0]),
                        name = (sdr[1]).ToString(),
                        email = Convert.ToString(sdr[2]),
                        password = Convert.ToString(sdr[3]),
                        cpassword = (sdr[4]).ToString()
                    };
                con.Close();
            }
            return View(Admin_obj);

        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Admin Admin_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "Edit_Admin_info "+id +",'"+ Admin_obj.name + "','" +
                        Admin_obj.email +
                       "','" + Admin_obj.password + "','" + Admin_obj.cpassword + "'";
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            Admin Admin_obj = new Admin();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Admin_detail " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    Admin_obj = new Admin
                    {
                        id = Convert.ToInt32(sdr[0]),
                        name = (sdr[1]).ToString(),
                        email = Convert.ToString(sdr[2]),
                        password = Convert.ToString(sdr[3]),
                        cpassword = (sdr[4]).ToString()
                    };
                con.Close();
            }
            return View(Admin_obj);

        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Admin Admin_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "clear_Admin " + id;
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
            return RedirectToAction("Index","Admin");

        }

    }
}
