using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookingWebsite.Controllers
{
    public class UsersController : Controller
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        IdentityDbContext identityContext;
        RoleManager<IdentityRole> roleManager;
        HotelASPContext context;

        public UsersController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IdentityDbContext identityContext,
            RoleManager<IdentityRole> roleManager,
            HotelASPContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.identityContext = identityContext;
            this.roleManager = roleManager;
            this.context = context;
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Index()
        {
            var model = context.GetUsersForIndex();
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            //await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            //await roleManager.CreateAsync(new IdentityRole("Admin"));
            //await roleManager.CreateAsync(new IdentityRole("Customer"));
            //var user = new IdentityUser("Superadmin");
            //var result = await userManager.CreateAsync(user, "Abc123!");
            //if (result.Succeeded)
            //{
            //    await userManager.AddToRoleAsync(user, "SuperAdmin");
            //}

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UsersRegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);


            var user = new IdentityUser(model.Username);

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(
                    nameof(UsersRegisterVM.Username),
                    result.Errors.First().Description);

                return View(model);
            }

            else if (result.Succeeded)
            {
                model.AspNetUserId = user.Id;

                await userManager.AddToRoleAsync(user, "Customer");

            }


            await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            context.AddUser(model);
            return RedirectToAction(nameof(UsersController.Index));

        }
        [Authorize]
        public IActionResult Details()
        {
            string userID = userManager.GetUserId(HttpContext.User);
            var model = context.FindUserById(userID);
            return View(model);



        }
        [Authorize]
        public IActionResult Edit()
        {

            return View();


        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(UsersEditVM model)
        {
            string userID = userManager.GetUserId(HttpContext.User);
            context.FindUserForEditByID(userID, model);
            return RedirectToAction(nameof(UsersController.Details));
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UsersLogInVM model)
        {
            if (!ModelState.IsValid) return View(model);


            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (!result.Succeeded)
            {

                return View(model);
            }

            return RedirectToAction(nameof(UsersController.Details));

        }

        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction(nameof(UsersController.LogIn));
        }
    }
}
