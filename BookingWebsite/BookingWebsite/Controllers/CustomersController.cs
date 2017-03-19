using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;

namespace BookingWebsite.Controllers
{
    public class CustomersController : Controller
    {
        TempDatabaseContext context;   

        public CustomersController(TempDatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var models = context.GetCustomersForIndex();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomersCreateVM customer)
        {
            if (!ModelState.IsValid)
                return View();
            
            context.AddCustomer(customer);
            Response.Cookies.Append("Password", customer.Password);
            Response.Cookies.Append("Username", customer.UserName);
            Response.Cookies.Append("Email", customer.Email);
            return RedirectToAction(nameof(CustomersController.CreateUser));
        }

        public IActionResult CreateUser()
        {
            var usr = new UserCreateVM
            {
                Password = Request.Cookies["Password"],
                Email = Request.Cookies["Email"],
                Username = Request.Cookies["Username"]
            };
            context.AddUser(usr);
            return RedirectToAction(nameof(CustomersController.Index));
        }

        public IActionResult Edit(int id)
        {
            var model = context.GetCustomerForDetail(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            context.EditCustomer(customer);
            return RedirectToAction(nameof(CustomersController.Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var model = context.GetCustomerForDetail(id);
            return View(model);
        }
    }
}
