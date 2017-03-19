using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class BookingsEditVM
    {
        [Display(Name = "Booking Id: ")]
        public int BookingId { get; set; }

        [Display(Name = "Room Id: ")]
        public int RoomId { get; set; }

        [Display(Name = "Customer Id: ")]
        public int CustomerId { get; set; }

        [Display(Name = "Booked from: ")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "To: ")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Status: ")]
        public int? Statuscode { get; set; }
    }
}
