using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using OnlineTicketBookingSystem.Models;
using OnlineTicketBookingSystem.Repository;

namespace OnlineTicketBookingSystem.Controllers
{
    public class UserController : Controller
    {
        //    
        // GET: /Customer/    
        [HttpGet]
        public ActionResult InsertUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertUser(UserAccount objUser)
        {

            objUser.Birthdate = Convert.ToDateTime(objUser.Birthdate);
            if (ModelState.IsValid) //checking model is valid or not    
            {
                UserRepository objDB = new UserRepository();
                bool result = objDB.InsertData(objUser);
                //ViewData["result"] = result;    
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model    
                                    //return View();    
                return RedirectToAction("InsertUser");
                ViewBag.Message = string.Format("Entered Successfully");
                return View();
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowAllUserDetails()
        {
            UserAccount objUser = new UserAccount();
            UserRepository objDB = new UserRepository(); //calling class DBdata    
            objUser.ShowallUser = objDB.Selectalldata();
            return View(objUser);
        }
        [HttpGet]
        public ActionResult Details(string ID)
        {    
            UserAccount objUser = new UserAccount();
            UserRepository objDB = new UserRepository(); //calling class DBdata    
            return View(objDB.SelectDatabyID(ID));
        }
        [HttpGet]
        public ActionResult Edit(string ID)
        {
            UserAccount objCustomer = new UserAccount();
            UserRepository objDB = new UserRepository(); //calling class DBdata    
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(UserAccount objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid) //checking model is valid or not    
            {
                UserRepository objDB = new UserRepository(); //calling class DBdata    
                string result = objDB.UpdateData(objCustomer);
                //ViewData["result"] = result;    
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    
                //return View();    
                return RedirectToAction("ShowAllUserDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(String ID)
        {
            UserRepository objDB = new UserRepository();
            int result = objDB.DeleteData(ID);
            TempData["result3"] = result;
            ModelState.Clear(); //clearing model    
                                //return View();    
            return RedirectToAction("ShowAllUserDetails");
        }
    }
}