using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineTicketBookingSystem.Models
{
    public class Booking
    {
        public int id { get; set; }

        [DisplayName("Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Moviename { get; set; }

        [DisplayName("Seat row")]
        [Required(ErrorMessage = "Message is required")]
        public string SeatRow { get; set; }

        [DisplayName("Seat number")]
        [Required(ErrorMessage = "Message is required")]
        public string Seatnumber { get; set; }

        [DisplayName("Total Price")]
        [Required(ErrorMessage = "Status is required")]
        public double Price { get; set; }
    }
    public enum Movies
    {
        Kantara, 
        WakandaForever,
        Gold
    }
    public enum SeatRow
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K
    }
}