using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class UsersRegisterVM
    {
        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string AspNetUserId { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Adress")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Second adress")]
        public string AddressLine2 { get; set; }
        [Display(Name = "Zipcode")]
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
