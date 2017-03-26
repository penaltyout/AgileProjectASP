using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingWebsite.Models;
using BookingWebsite.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

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

        public IActionResult Index()
        {
            var models = context.GetRoomsIndexVMForIndex();
            return View(models);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var model = context.GetRoomsDetailVMForDetail(id, env);
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
