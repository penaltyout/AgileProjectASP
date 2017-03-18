using System;
using System.Collections.Generic;

namespace BookingWebsite.Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Booking = new HashSet<Booking>();
            User = new HashSet<User>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Mobilephone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string SocialSecurityNumber { get; set; }
        public int? Statuscode { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
