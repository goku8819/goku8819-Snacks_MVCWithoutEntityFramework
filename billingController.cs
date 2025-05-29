using Snacks_MVCWithoutEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Net;

namespace Snacks_MVCWithoutEntityFramework.Controllers
{
    public class billingController : Controller
    {

        string dbconnection = @"Data Source= DESKTOP-666L8AI\SQLEXPRESS;Initial Catalog=snacks; Integrated Security = true";
        // GET: billing
        public ActionResult Index()
        {
            List<billing> billingObj = new List<billing>();
            using (SqlConnection con = new SqlConnection(dbconnection))
            {
                SqlCommand cmd = new SqlCommand("sp_billing_fetch", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    billingObj.Add(new billing
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        name = reader["name"].ToString(),
                        cost = Convert.ToInt32(reader["cost"].ToString()),
                        company = reader["company"].ToString(),
                    });

                }
                con.Close();
            }
            return View(billingObj);
        }

        // GET: billing/Details/5
        public ActionResult Details(int? id)
        {
            billing billingObj = new billing();
            using (SqlConnection con = new SqlConnection(dbconnection))
            {
                SqlCommand cmd = new SqlCommand("sp_billing_fetch_id " + id, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    billingObj = new billing
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        name = reader["name"].ToString(),
                        cost = Convert.ToInt32(reader["cost"].ToString()),
                        company = reader["company"].ToString(),
                    };

                }
                con.Close();
            }
            return View(billingObj);

        }

        // GET: billing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: billing/Create
        [HttpPost]
        public ActionResult Create(billing billingObj)
        {
            try
            {         // TODO: Add insert logic here
                using (SqlConnection con = new SqlConnection(dbconnection))
                {
                    string query = "sp_billing_insert '" + billingObj.name 
                        + "','" + billingObj.cost
                        + "','" + billingObj.company + "'";
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

        // GET: billing/Edit/5
        public ActionResult Edit(int? id)
        {
            billing billingObj = new billing();
            using (SqlConnection con = new SqlConnection(dbconnection))
            {
                SqlCommand cmd = new SqlCommand("sp_billing_fetch_id " + id, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    billingObj = new billing
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        name = reader["name"].ToString(),
                        cost = Convert.ToInt32(reader["cost"].ToString()),
                        company = reader["company"].ToString(),
                    };

                }
                con.Close();
            }
            return View(billingObj);
        }

        // POST: billing/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, billing billingObj)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection con = new SqlConnection(dbconnection))
                {
                    string query = "sp_billing_edit " + billingObj.id
                        + ",'" + billingObj.name 
                        + "','" + billingObj.cost
                        + "','" + billingObj.company + "'";
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

        // GET: billing/Delete/5
        public ActionResult Delete(int? id)
        {
            billing billingObj = new billing();
            using (SqlConnection con = new SqlConnection(dbconnection))
            {
                SqlCommand cmd = new SqlCommand("sp_billing_fetch_id " + id, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    billingObj = new billing
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        name = reader["name"].ToString(),
                        cost = Convert.ToInt32(reader["cost"].ToString()),
                        company = reader["company"].ToString(),
                    };

                }
                con.Close();
            }
            return View(billingObj);
        }

        // POST: billing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, billing billingObj)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection con = new SqlConnection(dbconnection))
                {
                    string query = "sp_billing_delete " + id;
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
