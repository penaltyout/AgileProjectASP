using System;
using System.Collections.Generic;

namespace BookingWebsite.Models.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Statuscode { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
