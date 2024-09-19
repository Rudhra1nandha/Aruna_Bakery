using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;
using Aruna_Bakery_WithoutEntity.Models;

namespace Aruna_Bakery_WithoutEntity.Controllers
{
    public class SigninController : Controller
    {
        string constr = WebConfigurationManager.ConnectionStrings["Aruna_bakery"].ConnectionString;

        public ActionResult Index()
        {
            List<Login> login_obj = new List<Login>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_bakery_index", con);
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    login_obj.Add(new Login
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = Convert.ToString(sdr["Name"]),
                        user_id = Convert.ToString(sdr["user_id"]),
                        phone_no = Convert.ToInt64(sdr["phone_no"]),
                        place = Convert.ToString(sdr["place"]),
                        gender = Convert.ToString(sdr["gender"]),
                        email = Convert.ToString(sdr["email"]),
                        password = Convert.ToString(sdr["password"]),
                        cpassword = Convert.ToString(sdr["cpassword"]),
                    }
                    );
                con.Close();
            }
            return View(login_obj);
        }


        // GET: Signin/Details/5
        public ActionResult Details(int id)
        {
            Login login_obj = new Login();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_detail_bakery " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    login_obj = new Login
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = Convert.ToString(sdr["Name"]),
                        user_id = Convert.ToString(sdr["user_id"]),
                        phone_no = Convert.ToInt64(sdr["phone_no"]),
                        place = Convert.ToString(sdr["place"]),
                        gender = Convert.ToString(sdr["gender"]),
                        email = Convert.ToString(sdr["email"]),
                        password = Convert.ToString(sdr["password"]),
                        cpassword = Convert.ToString(sdr["cpassword"]),
                    };
                con.Close();
            }
            return View(login_obj);
        }

        // GET: Signin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Signin/Create
        [HttpPost]
        public ActionResult Create(Login login_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "sp_Signup_index "
                        + "'" + login_obj.Name + "','" + login_obj.user_id + "'," + login_obj.phone_no + ",'"
                        + login_obj.place + "','" + login_obj.gender + "','" + login_obj.email + "','"
                        + login_obj.password + "','" + login_obj.cpassword + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        ViewBag.Signup = true;
                        return RedirectToAction("index");
                    }
                }
                return View(login_obj);
            }
            catch
            {
                return View();
            }
        }

        // GET: Signin/Edit/5
        public ActionResult Edit(int id)
        {
            Login login_obj = new Login();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_detail_bakery " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    login_obj = new Login
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = Convert.ToString(sdr["Name"]),
                        user_id = Convert.ToString(sdr["user_id"]),
                        phone_no = Convert.ToInt64(sdr["phone_no"]),
                        place = Convert.ToString(sdr["place"]),
                        gender = Convert.ToString(sdr["gender"]),
                        email = Convert.ToString(sdr["email"]),
                        password = Convert.ToString(sdr["password"]),
                        cpassword = Convert.ToString(sdr["cpassword"]),
                    };
                con.Close();
            }
            return View(login_obj);
        }

        // POST: Signin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Login login_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "sp_edit_bakery "
                        + id + ",'" + login_obj.Name + "','" + login_obj.user_id + "'," + login_obj.phone_no
                        + ",'"
                        + login_obj.place + "','" + login_obj.gender + "','" + login_obj.email + "','"
                        + login_obj.password + "','" + login_obj.cpassword + "'";
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

        // GET: Signin/Delete/5
        public ActionResult Delete(int id)
        {
            Login login_obj = new Login();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_detail_bakery " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    login_obj = new Login
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = Convert.ToString(sdr["Name"]),
                        user_id = Convert.ToString(sdr["user_id"]),
                        phone_no = Convert.ToInt64(sdr["phone_no"]),
                        place = Convert.ToString(sdr["place"]),
                        gender = Convert.ToString(sdr["gender"]),
                        email = Convert.ToString(sdr["email"]),
                        password = Convert.ToString(sdr["password"]),
                        cpassword = Convert.ToString(sdr["cpassword"]),
                    };
                con.Close();
            }
            return View(login_obj);
        }

        // POST: Signin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Login login_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "sp_delete_bakery " + id;
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

        public ActionResult Sign_in()
        {
            return View();
        }

        // POST: signup/Delete/5
        [HttpPost]
        public ActionResult Sign_in(Login login_obj)
        {
            try
            {
                string AdminName = "";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "sp_find_admin '" + login_obj.email + "','" + login_obj.password + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        AdminName = sdr[0].ToString();
                    }
                    con.Close();
                }

                // employee login
                string Name = "";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "sp_login '" + login_obj.email + "','" + login_obj.password + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        Name = sdr[0].ToString();
                    }
                    con.Close();
                }

                Session["AdminName"] = AdminName;
                Session["Employeename"] = Name;

                //login validation
                if (AdminName != "")
                {
                    ViewBag.sucess = true;
                    return RedirectToAction("Index", "Admin");
                }
                else if (Name != "")
                {
                    return RedirectToAction("Index", "Orders");
                }
                else { return View(); }


            }
            catch
            {
                return View();
            }
        }
        public ActionResult Signup()
        {
            return View();
        }

        // POST: sign_in/Delete/5
        [HttpPost]
        public ActionResult Signup(Login login_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "sp_Signup_index "
                        + "'" + login_obj.Name + "','" + login_obj.user_id + "'," + login_obj.phone_no + ",'"
                        + login_obj.place + "','" + login_obj.gender + "','" + login_obj.email + "','"
                        + login_obj.password + "','" + login_obj.cpassword + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        ViewBag.Signup = true;
                        return RedirectToAction("Sign_in");
                    }
                }
                return View(login_obj);
            }
            catch
            {
                return View();
            }
        }

    }
}
