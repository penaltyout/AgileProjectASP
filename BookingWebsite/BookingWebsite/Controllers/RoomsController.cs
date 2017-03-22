using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;

namespace BookingWebsite.Controllers
{
    public class RoomsController : Controller
    {
        private IHostingEnvironment env;

        HotelASPContext context;

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

        //[HttpGet]
        //public IActionResult Detail(int id)
        //{
        //    var model = context.GetRoomsDetailVMForDetail(id);
        //    return View(model);
        //}

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
            Room room = context.GetRoomForDetail(id);
            RoomsDetailVM model = new RoomsDetailVM(env)
            {
                Id = room.Id,
                Name = room.Name,
                Number = room.Number,
                Price = room.Price,
                Size = room.Size,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(RoomsEditVM room)
        {
            if (!ModelState.IsValid)
                return View();

            context.EditRoom(room);
            return RedirectToAction(nameof(RoomsController.Index));
        }

        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return View();

            context.DeleteRoom(id);
            return RedirectToAction(nameof(RoomsController.Index));
        }
    }
}
