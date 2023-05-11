using KUMF5H_ASP_2022232.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KUMF5H_ASP_2022232.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<FoodUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(FoodRequestController.Index), "FoodRequest");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> RemoveAdmin()
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == _userManager.GetUserId(User));
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction(nameof(FoodRequestController.Index), "FoodRequest");
        }

        [Authorize]
        public async Task<IActionResult> GrantAdmin()
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == _userManager.GetUserId(User));
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(FoodRequestController.Index), "FoodRequest");
        }
    }
}