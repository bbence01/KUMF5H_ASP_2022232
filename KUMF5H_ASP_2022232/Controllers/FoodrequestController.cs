﻿using KUMF5H_ASP_2022232.Data;
using KUMF5H_ASP_2022232.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KUMF5H_ASP_2022232.Controllers
{
    public class FoodrequestController : Controller
    {
        private readonly IFoodRequestRepository repository;
        private readonly UserManager<FoodUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public FoodrequestController(IFoodRequestRepository repository, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetAll().OrderBy(f => f.IsDone));
        }

        public IActionResult Details(string id)
        {
            var food = this.repository.GetOne(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


      

    


   

 
    }
}
