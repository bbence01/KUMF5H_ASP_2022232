﻿using KUMF5H_ASP_2022232.Data;
using KUMF5H_ASP_2022232.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KUMF5H_ASP_2022232.Controllers
{
    public class FoodRequestController : Controller
    {
        private readonly IFoodRequestRepository foodrepository;
        private readonly IOfferRepository offerrepository;
        private readonly IFoodUserRepository foodUserRepository;
        private readonly UserManager<FoodUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public FoodRequestController(IFoodRequestRepository frrepository, IFoodUserRepository foodUserRepository, IOfferRepository offerRepo, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.foodrepository = frrepository;
            this.offerrepository = offerRepo;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.foodUserRepository = foodUserRepository;
        }

        public IActionResult Index()
        {
            return View(this.foodrepository.GetAll().OrderBy(f => f.IsDone));
        }

        public IActionResult Details(string id)
        {
            var food = this.foodrepository.GetOne(id);
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
            FoodRequest f = this.foodrepository.GetOne(id);
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

                this.foodrepository.Create(n);
                return RedirectToAction(nameof(Index));
            }
            return View(foodrequest);
        }


        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var product = this.foodrepository.GetOne(id);
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
                var old = this.foodrepository.GetOne(id);

                if (old.Requestor.Id != userManager.GetUserId(User) && !User.IsInRole("Admin"))
                    return RedirectToAction(nameof(Index));

                old.Name = foodrequest.Name;
                old.Description = foodrequest.Description;
                old.IsDone = foodrequest.IsDone;
                old.Payment = foodrequest.Payment;
                old.Deliveryoptions = foodrequest.Deliveryoptions;
                this.foodrepository.Update(old);
                return RedirectToAction(nameof(Index));
            }

            return View(foodrequest);
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            var foodrequest = this.foodrepository.GetOne(id);

            if (foodrequest != null && (foodrequest.Requestor.Id == userManager.GetUserId(User) || User.IsInRole("Admin")))
            {
                this.foodrepository.Delete(foodrequest);
            }

            return RedirectToAction(nameof(Index));


        }

        [Authorize]
        public IActionResult ChooseOffer(string foodId, string offerId)
        {
            var food = this.foodrepository.GetOne(foodId);
            var offer = this.offerrepository.GetOne(offerId);
            var contractor = this.foodUserRepository.GetFooduserById(offer.ContractorId);
            var requestor = this.foodUserRepository.GetFooduserById(userManager.GetUserId(User));


            if (food == null || food.Requestor.Id != userManager.GetUserId(User))
                return RedirectToAction(nameof(Index));

            food.InProgress = true;
            offer.Choosen = true;
            food.Contractor = contractor;



            this.foodrepository.Update(food);
            this.offerrepository.Update(offer);


            return RedirectToAction(nameof(Details), "FoodRequest", new { id = foodId });
        }

        [Authorize]
        public IActionResult SeeAcceptedOffers()
        {
            var foodrequest = this.foodrepository.SeeAcceptedOffers(userManager.GetUserId(User));

            return View(foodrequest);
        }


        [Authorize]
        public IActionResult SeeOtherAcceptedOffers(string id)
        {
            var foodrequest = this.foodrepository.SeeAcceptedOffers(id);

            return View(foodrequest);
        }


        [Authorize]
        public IActionResult CompleteRequest(string foodId)
        {
            var food = this.foodrepository.GetOne(foodId);
            var chosenOffer = food.Offers.FirstOrDefault(o => o.Choosen);
            var requestor = this.foodUserRepository.GetFooduserById(food.RequestorId);
            var contractor = this.foodUserRepository.GetFooduserById(userManager.GetUserId(User));

            if (food == null || chosenOffer.ContractorId != userManager.GetUserId(User))
                return RedirectToAction(nameof(Index));


            contractor.Founds = contractor.Founds + food.Payment;

            requestor.Founds = requestor.Founds - food.Payment;

            food.IsDone = true;
            this.foodrepository.Update(food);

            return RedirectToAction(nameof(Details), "FoodRequest", new { id = foodId });
        }


        [Authorize]
        public IActionResult CancelRequest(string foodId)
        {
            var food = this.foodrepository.GetOne(foodId);
            var chosenOffer = food.Offers.Where(x=>x.Choosen==true).First();

            if (food == null || (food.RequestorId != userManager.GetUserId(User) && chosenOffer.ContractorId != userManager.GetUserId(User)))
                return RedirectToAction(nameof(Index));

            food.IsDone = false;
            food.InProgress = false;
            food.Contractor = null;


            if (chosenOffer != null)
            {
                chosenOffer.Choosen = false;
                this.offerrepository.Update(chosenOffer);
            }

            this.foodrepository.Update(food);

            return RedirectToAction(nameof(Details), "FoodRequest", new { id = foodId });
        }



    }
}
