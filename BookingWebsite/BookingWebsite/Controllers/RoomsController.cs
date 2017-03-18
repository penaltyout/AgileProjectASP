using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;

namespace BookingWebsite.Controllers
{
    public class RoomsController : Controller
    {
        TempDatabaseContext context;

        public RoomsController(TempDatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var models = context.GetRoomsForIndex();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomsCreateVM room)
        {
            if (!ModelState.IsValid)
                return View();

            context.AddRoom(room);
            return RedirectToAction(nameof(RoomsController.Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var model = context.GetRoomForDetail(id);
            return View(model);
        }
    }
}
