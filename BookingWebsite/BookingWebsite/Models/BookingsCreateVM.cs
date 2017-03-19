using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class BookingsCreateVM
    {
        [Display(Name = "Booking Id: ")]
        [Required(ErrorMessage = "*Booking Id required")]
        public int BookingId { get; set; }

        [Display(Name = "Room Id: ")]
        [Required(ErrorMessage = "*Room Id required")]
        public int RoomId { get; set; }

        [Display(Name = "Customer Id: ")]
        [Required(ErrorMessage = "*Customer Id required")]
        public int CustomerId { get; set; }

        [Display(Name = "Start date: ")]
        [Required(ErrorMessage = "*Start date required")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End date: ")]
        [Required(ErrorMessage = "*End date required")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Status: ")]
        [Required(ErrorMessage = "*Status code required")]
        public int? Statuscode { get; set; }
    }
}
