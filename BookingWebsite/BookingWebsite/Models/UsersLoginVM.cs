using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class UsersLogInVM
    {
        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
