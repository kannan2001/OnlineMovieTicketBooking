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
    public class MovieShowController : Controller
    {
        [HttpGet]
        public ActionResult GetAllShowDetails()
        {

            ShowsRepository ShowRepo = new ShowsRepository();
            ModelState.Clear();
            return View(ShowRepo.GetAllShows());
        }
        [HttpGet]
        public ActionResult AddShows()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddShows(MovieShows Show)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ShowsRepository EmpRepo = new ShowsRepository();

                    if (EmpRepo.AddShows(Show))
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
        [HttpGet]
        public ActionResult EditShowDetails(int id)
        {
            ShowsRepository ShowRepo = new ShowsRepository();
            return View(ShowRepo.GetAllShows().Find(Show => Show.Showid == id));
        }
        [HttpPost]
        public ActionResult EditShowDetails(int id, MovieShows obj)
        {
            try
            {
                ShowsRepository ShowRepo = new ShowsRepository();
                ShowRepo.UpdateShows(obj);
                return RedirectToAction("GetAllShowDetails");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteShows(int id)
        {
            try
            {
                ShowsRepository EmpRepo = new ShowsRepository();
                if (EmpRepo.DeleteShows(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllShowDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}