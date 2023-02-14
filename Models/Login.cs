using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OnlineTicketBookingSystem.Models
{
    public class Login
    {//Username 
        [Display(Name = "id")]
        public int UserID { get; set; }
        [Required(ErrorMessage = "User Name required.")]

        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        //Password
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}