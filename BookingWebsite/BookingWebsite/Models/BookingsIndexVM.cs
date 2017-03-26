using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class BookingsIndexVM
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Statuscode { get; set; }
    }
}
