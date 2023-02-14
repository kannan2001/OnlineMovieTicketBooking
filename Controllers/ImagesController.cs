using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicketBookingSystem.Models;
using OnlineTicketBookingSystem.Repository;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
namespace OnlineTicketBookingSystem.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult GetImages()
        {
            ImagesRepository RoutesRepo = new ImagesRepository();
            ModelState.Clear();
            return View(RoutesRepo.GetImages());
        }
        public ActionResult AddImage() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddImage(ImagesMovie image,HttpPostedFileBase file)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(mainconn);
            SqlCommand sqlcomm = new SqlCommand("AddNewImage");
            sqlcon.Open();
            sqlcomm.Connection = sqlcon;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.CommandText = "AddNewImage";
            //sqlcomm.Parameters.AddWithValue("@Brand", routes.Brand);
            if (file != null && file.ContentLength > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/Movie-Images/"), filename);
                file.SaveAs(imgpath);
            }
            sqlcomm.Parameters.AddWithValue("@MovieImage", "~/Movie-Images/" + file.FileName);
            sqlcomm.Parameters.AddWithValue("@Description", image.Description);
            sqlcomm.Parameters.AddWithValue("@Name ", image.Name);
            sqlcomm.ExecuteNonQuery();
            sqlcon.Close();
            ViewBag.Message = "record was saved successfully";

            return View();
        }
    }
}