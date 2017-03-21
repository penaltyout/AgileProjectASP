using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class RoomsEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Number required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "*Description required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "*Price required")]
        public int? Price { get; set; }

        [Required(ErrorMessage = "*Size required")]
        public int? Size { get; set; }

        [Display(Name = "Status code")]
        [Required(ErrorMessage = "*Status code required")]
        public int? Statuscode { get; set; }
    }
}
