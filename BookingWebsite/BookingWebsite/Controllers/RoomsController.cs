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
        HotelASPContext context;

        public RoomsController(HotelASPContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var models = context.GetRoomsIndexVMsForIndex();
            return View(models);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = context.GetRoomsDetailsVMForDetails(id);
            return View(model);
        }

        // [Authorize(Roles = "Superadmin, Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // [Authorize(Roles = "Superadmin, Admin")]
        [HttpPost]
        public IActionResult Create(RoomsCreateVM room)
        {
            if (!ModelState.IsValid)
                return View();

            context.CreateRoom(room);
            return RedirectToAction(nameof(RoomsController.Index));
        }

        // [Authorize(Roles = "Superadmin, Admin")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        // [Authorize(Roles = "Superadmin, Admin")]
        [HttpPost]
        public IActionResult Edit(RoomsEditVM room)
        {
            if (!ModelState.IsValid)
                return View();

            context.EditRoom(room);
            return RedirectToAction(nameof(RoomsController.Index));
        }

        // [Authorize(Roles = "Superadmin, Admin")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return View();

            context.DeleteRoom(id);
            return RedirectToAction(nameof(RoomsController.Index));
        }
    }
}
