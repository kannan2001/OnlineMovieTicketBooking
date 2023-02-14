using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineTicketBookingSystem.Models;
using OnlineTicketBookingSystem.Repository;

namespace OnlineTicketBookingSystem.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login User)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            SqlCommand sqlcomm = new SqlCommand("Login_pro");
            sqlconn.Open();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.CommandText = "Login_pro";
            sqlcomm.Parameters.AddWithValue("@Username", User.Username);
            sqlcomm.Parameters.AddWithValue("@Password", User.Password);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {
                if (User.Username == "AdminLogin" || User.Password == "Admin123")
                {
                    FormsAuthentication.SetAuthCookie(User.Username, true);
                    Session["Username"] = User.Username.ToString();
                    FormsAuthentication.SetAuthCookie(User.Password, true);
                    Session["Password"] = User.Password.ToString();
                    return RedirectToAction("UserDisplay", "Admin");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(User.Username, true);
                    Session["Username"] = User.Username.ToString();
                    FormsAuthentication.SetAuthCookie(User.Password, true);
                    Session["Password"] = User.Password.ToString();
                    return RedirectToAction("UserHomePage", "UserHome");
                }
            }
            else
            {
                ViewData["message"] = "login failed!!";
            }
            sqlconn.Close();
            ViewBag.Message = "login successfully!";
            return View();
        }

    }
}