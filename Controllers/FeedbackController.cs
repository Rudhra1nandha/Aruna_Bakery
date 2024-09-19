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
    public class FeedbackController : Controller
    {
        string constr = WebConfigurationManager.ConnectionStrings["Aruna_bakery"].ConnectionString;

        // GET: Feedback
        public ActionResult Index()
        {
            List<Feedback> feedback_obj = new List<Feedback>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Sp_feedback", con);
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    feedback_obj.Add(new Feedback()
                    {
                        id = Convert.ToInt32(sdr[0]),
                        name = (sdr[1]).ToString(),
                        email = Convert.ToString(sdr[2]),
                        Ratings = Convert.ToInt32(sdr[3]),
                        Comment = (sdr[4]).ToString()
                    });
                con.Close();
            }
            return View(feedback_obj);
        }

        // GET: Feedback/Details/5
        public ActionResult Details(int id)
        {
            Feedback feedback_obj = new Feedback();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Sp_feedback_id "+id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    feedback_obj = new Feedback
                    {
                        id = Convert.ToInt32(sdr[0]),
                        name = (sdr[1]).ToString(),
                        email = Convert.ToString(sdr[2]),
                        Ratings = Convert.ToInt32(sdr[3]),
                        Comment = (sdr[4]).ToString()
                    };
                con.Close();
            }
            return View(feedback_obj);
        }

        // GET: Feedback/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedback/Create
        [HttpPost]
        public ActionResult Create(Feedback feedback_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "Sp_new_feedback '" + feedback_obj.name + "','" + feedback_obj.email +
                       "'," + feedback_obj.Ratings + ",'" + feedback_obj.Comment + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Feedback/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Feedback/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Feedback/Delete/5
        public ActionResult Delete(int id)
        {
            Feedback feedback_obj = new Feedback();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Sp_feedback_id " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    feedback_obj = new Feedback
                    {
                        id = Convert.ToInt32(sdr[0]),
                        name = (sdr[1]).ToString(),
                        email = Convert.ToString(sdr[2]),
                        Ratings = Convert.ToInt32(sdr[3]),
                        Comment = (sdr[4]).ToString()
                    };
                con.Close();
            }
            return View(feedback_obj);
        }

        // POST: Feedback/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Feedback feedback_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "Sp_delete_feedback " +id ;
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
