using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingWebsite.Controllers
{
    public class BookingsController : Controller
    {
        TempDatabaseContext context;

        public BookingsController(TempDatabaseContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
                return View();
            else
            {
                var models = context.GetBookingsForIndex();

                return View(models);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookingsCreateVM booking)
        {
            if (!ModelState.IsValid)
                return View();

            context.AddBooking(booking);
            return RedirectToAction(nameof(BookingsController.Index));
        }

        #region Non-functional
        //public IActionResult Edit(int id)
        //{
        //    var model = context.GetBookingById(id);
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Edit(Booking booking)
        //{
        //    context.EditBooking(booking);
        //    return RedirectToAction(nameof(BookingsController.Index));
        //}
        #endregion
    }
}
