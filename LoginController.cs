using Snacks_MVCWithoutEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snacks_MVCWithoutEntityFramework.Controllers
{
    public class LoginController : Controller
    {

        string dbconnection = @"Data Source= DESKTOP-666L8AI\SQLEXPRESS;Initial Catalog=snacks; Integrated Security = true";

        // GET: login
        public ActionResult Index()
        {
            return View();
        }

        // GET: login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: billing/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: billing/Create
        [HttpPost]
        public ActionResult CreateUser(login loginobj)
        {
            try
            {
                string filename = "";
                HttpPostedFileBase file = loginobj.UploadImage;
                if (file != null)

                {
                    string fileextension = Path.GetExtension(loginobj.UploadImage.FileName);
                    if (fileextension == ".png" || fileextension == ".jpg" || fileextension == ".jpeg")
                    {
                        filename = loginobj.UploadImage.FileName;

                        //file name with path create 
                        filename = Path.Combine(Server.MapPath("~/Content/profile/"), filename);
                        loginobj.UploadImage.SaveAs(filename);


                    //TODO: Add insert logic here
                        using (SqlConnection con = new SqlConnection(dbconnection))
                        {
                            string query = "sp_login_insert '" + loginobj.name
                                + "','" + loginobj.uname
                                + "','" + loginobj.pwd
                                + "','" + filename + "'";

                            SqlCommand cmd = new SqlCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }

                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.ErrorMSG2 = "Select PNG , JPG and JPEG Formats Only !";
                       // return View(loginobj);
                        return JavaScript("<script>alert(\"Please give valid images\"</script>");

                    }
                }
            }

            catch
            {
                return View();
            }    
          return View();
        
        }



        public ActionResult Login()
        {
            return View();
        }

        // POST: billing/Create
        [HttpPost]
        public ActionResult Login(login loginobj)
        {
            //try
            //{         // TODO: Add insert logic here
                using (SqlConnection con = new SqlConnection(dbconnection))
                {
                    string query = "sp_login '" + loginobj.uname
                        + "','" + loginobj.pwd + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read()) 
                    {
                        Session["LoggedInUser"] = reader[0].ToString();
                        return RedirectToAction("Index","billing");
                    }
                    //cmd.ExecuteNonQuery();
                    con.Close();
                    return View();
                }              
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: login/Edit/5
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

        // GET: login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
