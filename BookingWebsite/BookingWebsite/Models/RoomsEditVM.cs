using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class RoomsEditVM
    {
        [HiddenInput]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Number { get; set; }
        
        public string Description { get; set; }
        
        public int? Price { get; set; }
        
        public int? Size { get; set; }

        [Display(Name = "Status code")]
        public int? Statuscode { get; set; }
    }
}
