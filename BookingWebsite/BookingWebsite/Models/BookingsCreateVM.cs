﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class BookingsCreateVM
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Room Id")]
        public int RoomId { get; set; }

        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Status code")]
        public int? Statuscode { get; set; }
    }
}
