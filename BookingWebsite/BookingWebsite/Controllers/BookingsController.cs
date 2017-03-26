using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BookingWebsite.Controllers
{
    public class BookingsController : Controller
    {
        UserManager<IdentityUser> userManager;
        HotelASPContext context;

        public BookingsController(HotelASPContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var models = context.GetBookingsIndexVMForIndex();
            return View(models);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(BookingsCreateVM booking)
        {
            booking.UserId = context.GetUserIdFromAspNetUserId(userManager.GetUserId(HttpContext.User));
            context.CreateBooking(booking);
            return View(booking);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            int bookingUserId = context.GetUserIdFromAspNetUserId(userManager.GetUserId(HttpContext.User));

            var model = context.GetBookingsDetailVMForUserBookingsDetail(bookingUserId);
            return View(model);
        }
    }
}