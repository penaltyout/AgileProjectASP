using System;
using System.Collections.Generic;

namespace BookingWebsite.Models.Entities
{
    public partial class Room
    {
        public Room()
        {
            Booking = new HashSet<Booking>();
        }

        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
        public int? Statuscode { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
