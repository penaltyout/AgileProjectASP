using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class CustomersCreateVM
    {
        [Required(ErrorMessage = "Must enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Must enter a last name")]
        public string LastName { get; set; }

        
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Must enter a Phone number")]
        public string Mobilephone { get; set; }

        [Required(ErrorMessage = "Must enter an adress")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Must enter a Zip code ")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Must enter a city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Must enter an email")]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "Must enter a Social security number")]
        public string SocialSecurityNumber { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

    }
}
