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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
