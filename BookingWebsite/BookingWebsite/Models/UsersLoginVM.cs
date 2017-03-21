using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class UsersLogInVM
    {
        [Required(ErrorMessage = "Must enter a username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
