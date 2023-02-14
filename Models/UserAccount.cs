using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OnlineTicketBookingSystem.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First name required")]
        [Display(Name = "First name")]
        [StringLength(10, ErrorMessage = "Name should be less than or equal to ten characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        [DisplayName("Last Name")]
        [StringLength(10, ErrorMessage = "Name should be less than or equal to ten characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mobile number required")]
        [DisplayName("Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string MobNumber { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Your DOB.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [OnlineTicketBookingSystem.Models.CustomValidationAttributeDemo.ValidBirthDate(ErrorMessage = "Birth Date can not be greater than current date")]
        [Display(Name = "Birth Date")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Enter Your EmailID")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<UserAccount> ShowallUser { get; set; }
    }
}