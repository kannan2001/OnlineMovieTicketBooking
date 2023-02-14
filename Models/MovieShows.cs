using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OnlineTicketBookingSystem.Models
{
    public class MovieShows
    {
        [Display(Name = "Id")]
        public int Showid { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "Movie name")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "Screen number is required")]
        [Display(Name = "Screen number")]
        public int ScreenNo { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        public DateTime StartTime { get; set; }

        public double Price { get; set; }
    }
}