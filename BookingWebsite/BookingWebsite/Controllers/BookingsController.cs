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
        public IActionResult UserBookingsDetails(int id)
        {
            int bookingUserId = context.GetUserIdFromAspNetUserId(userManager.GetUserId(HttpContext.User));

            var model = context.GetBookingsDetailsVMForUserBookingsDetails(bookingUserId);
            return View(model);

        }

        //[Authorize]
        //public IActionResult BookingSuccessfull(int id)
        //{
        //    BookingsSuccessfullVM booking = context.GetBookingsSuccessfullVMForBookingsSuccessfull(id);

        //    return View(booking);
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(BookingsCreateVM booking)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    context.AddBooking(booking);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Edit(int id)
        //{
        //    var model = context.GetBookingForDetail(id);
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Edit(Booking booking)
        //{
        //    context.EditBooking(booking);
        //    return RedirectToAction(nameof(BookingsController.Index));
        //}
    }
}