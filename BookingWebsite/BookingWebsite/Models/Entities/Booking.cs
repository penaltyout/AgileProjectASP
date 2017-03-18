using System;
using System.Collections.Generic;

namespace BookingWebsite.Models.Entities
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int Room_Id { get; set; }
        public int Customer_Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Statuscode { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
    }
}
