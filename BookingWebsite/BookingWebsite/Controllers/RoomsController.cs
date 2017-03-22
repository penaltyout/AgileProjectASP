using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace BookingWebsite.Controllers
{
    public class RoomsController : Controller
    {
        HotelASPContext context;
        IHostingEnvironment env;

        public RoomsController(HotelASPContext context, IHostingEnvironment env)
        {
            this.context = context;
            this.env = env;
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
            var model = context.GetRoomsDetailsVMForDetails(id, env);
            return View(model);
        }

        [Authorize(Roles = "Superadmin, Admin, Customer")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Superadmin, Admin, Customer")]
        [HttpPost]
        public IActionResult Create(RoomsCreateVM room)
        {
            if (!ModelState.IsValid)
                return View();

            context.CreateRoom(room);
            return RedirectToAction(nameof(RoomsController.Index));
        }

        [Authorize(Roles = "Superadmin, Admin, Customer")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = context.GetRoomForEditById(id);
            return View(model);
        }

        [Authorize(Roles = "Superadmin, Admin, Customer")]
        [HttpPost]
        public IActionResult Update(RoomsEditVM room)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(RoomsController.Edit));

            context.UpdateRoom(room);
            return RedirectToAction(nameof(RoomsController.Index));
        }

        [Authorize(Roles = "Superadmin, Admin, Customer")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return View();

            context.DeleteRoom(id);
            return RedirectToAction(nameof(RoomsController.Index));
        }
    }
}
