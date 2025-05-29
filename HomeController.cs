using Snacks_MVCWithoutEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snacks_MVCWithoutEntityFramework.Controllers
{
    public class HomeController : Controller
    { 

         string dbconnection = @"Data Source= DESKTOP-666L8AI\SQLEXPRESS;Initial Catalog=snacks; Integrated Security = true";

    
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult ContactUs()
        {
            return View();
        }

        // POST: billing/Create
        [HttpPost]
        public ActionResult ContactUs(ContactUs ContactUsobj)
        {
            try
            {         // TODO: Add insert logic here
                using (SqlConnection con = new SqlConnection(dbconnection))
                {
                    string query = "sp_contactus_insert '" + ContactUsobj.name
                        + "','" + ContactUsobj.emailid
                        + "','" + ContactUsobj.phone + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }



    }
}