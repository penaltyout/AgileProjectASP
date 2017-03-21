using System;
using System.Collections.Generic;

namespace BookingWebsite.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int? Statuscode { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
