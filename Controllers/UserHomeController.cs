using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicketBookingSystem.Models;
using OnlineTicketBookingSystem.Repository;

namespace OnlineTicketBookingSystem.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        public ActionResult UserHomePage()
        {
            return View();
        }
    }
}
