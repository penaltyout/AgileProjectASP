using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class RoomsIndexVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? Size { get; set; }
        public int? Statuscode { get; set; }
    }
}