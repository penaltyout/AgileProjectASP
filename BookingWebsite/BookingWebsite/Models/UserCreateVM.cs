using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class UserCreateVM
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
