using OnlineTicketBookingSystem.Models;
using OnlineTicketBookingSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicketBookingSystem.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult UserDisplay()
        {
            return View();
        }

    }
}