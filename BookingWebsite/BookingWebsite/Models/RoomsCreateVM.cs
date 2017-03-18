using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class RoomsCreateVM
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "*Name required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "*Description required")]
        public string Description { get; set; }
    }
}
