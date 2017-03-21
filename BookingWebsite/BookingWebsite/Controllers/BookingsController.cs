using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;

namespace BookingWebsite.Controllers
{
    public class BookingsController : Controller
    {
        HotelASPContext context;

        public BookingsController(HotelASPContext context)
        {
            this.context = context;
        }

        //public IActionResult Index()
        //{
        //    if (!ModelState.IsValid)
        //        return View();
        //    else
        //    {
        //        var models = context.GetBookingsForIndex();

        //        return View(models);
        //    }
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

        //[HttpGet]
        //public IActionResult Detail(int id)
        //{
        //    var model = context.GetBookingForDetail(id);
        //    return View(model);
        //}
    }
}