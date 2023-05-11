using KUMF5H_ASP_2022232.Data;
using KUMF5H_ASP_2022232.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KUMF5H_ASP_2022232.Controllers
{
    public class FoodRequestController : Controller
    {
        private readonly IFoodRequestRepository repository;
        private readonly UserManager<FoodUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public FoodRequestController(IFoodRequestRepository repository, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
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



        [HttpGet("Image")]
        public IActionResult GetImage(string id)
        {
            FoodRequest f = this.repository.GetOne(id);
            if (f == null)
            {
                return NotFound();
            }

            return new FileContentResult(f.Picture, f.PictureContentType);
        }



        [HttpPost]
        [Authorize]
        public IActionResult Create(FoodRequestViewModel foodrequest, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                FoodRequest n = new FoodRequest()
                {
                    Name = foodrequest.Name,
                    Description = foodrequest.Description,
                    RequestorId = userManager.GetUserId(User),
                    Payment = foodrequest.Payment,
                    Deliveryoptions = foodrequest.Deliveryoptions
                };
                using (var stream = picture.OpenReadStream())
                {
                    byte[] buffer = new byte[picture.Length];
                    stream.Read(buffer, 0, (int)picture.Length);
                    n.Picture = buffer;
                    n.PictureContentType = picture.ContentType;
                }

                this.repository.Create(n);
                return RedirectToAction(nameof(Index));
            }
            return View(foodrequest);
        }


        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var product = this.repository.GetOne(id);
            if (product != null && (product.Requestor.Id == userManager.GetUserId(User) || User.IsInRole("Admin")))
            {
                return View(product);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(string id, FoodRequestViewModel foodrequest)
        {
            if (ModelState.IsValid)
            {
                var old = this.repository.GetOne(id);

                if (old.Requestor.Id != userManager.GetUserId(User) && !User.IsInRole("Admin"))
                    return RedirectToAction(nameof(Index));

                old.Name = foodrequest.Name;
                old.Description = foodrequest.Description;
                old.IsDone = foodrequest.IsDone;
                old.Payment = foodrequest.Payment;
                old.Deliveryoptions = foodrequest.Deliveryoptions;
                this.repository.Update(old);
                return RedirectToAction(nameof(Index));
            }

            return View(foodrequest);
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            var foodrequest = this.repository.GetOne(id);

            if (foodrequest != null && (foodrequest.Requestor.Id == userManager.GetUserId(User) || User.IsInRole("Admin")))
            {
                this.repository.Delete(foodrequest);
            }

            return RedirectToAction(nameof(Index));


        }

        [Authorize]
        public IActionResult ChooseOffer(string foodId)
        {
            var food = this.repository.GetOne(foodId);

            if (food == null || food.Requestor.Id != userManager.GetUserId(User))
                return RedirectToAction(nameof(Index));

            food.IsDone = true;
            this.repository.Update(food);

            return RedirectToAction(nameof(Details), "FoodRequest", new { id = foodId });
        }

        [Authorize]
        public IActionResult SeeAcceptedOffers()
        {
            var products = this.repository.SeeAcceptedOffers(userManager.GetUserId(User));

            return View(products);
        }

    }
}
