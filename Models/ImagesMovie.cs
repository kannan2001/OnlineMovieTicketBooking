using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicketBookingSystem.Models
{
    public class ImagesMovie
    {
        [Display(Name = "id")]
        public int id { get; set; }

        [Required(ErrorMessage ="Upload Image!")]
        [Display(Name ="Movie Image")]
        public string MovieImage { get; set; }
        [Required(ErrorMessage = "Description Required!")]
        public string Description { get; set; }

        public string Name { get; set; }
    }
}