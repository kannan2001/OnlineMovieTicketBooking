using OnlineTicketBookingSystem.Models;
using OnlineTicketBookingSystem.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicketBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking/GetAllTktDetails    
        public ActionResult GetAllTktDetails()
        {

            TicketRepository EmpRepo = new TicketRepository();
            ModelState.Clear();
            return View(EmpRepo.GetAllTickets());
        }
        // GET: Employee/AddTicket    
        public ActionResult AddTicket()
        {
            return View();
        }

        // POST: Employee/AddTicket    
        [HttpPost]
        public ActionResult AddTicket(Booking Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TicketRepository EmpRepo = new TicketRepository();

                    if (EmpRepo.AddTicket(Emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Booking()
        {
            return View();
        }
        public ActionResult SeatsRemaining()
        {
            return View();  
        }
    }
}

