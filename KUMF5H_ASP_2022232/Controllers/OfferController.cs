using KUMF5H_ASP_2022232.Data;
using KUMF5H_ASP_2022232.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace KUMF5H_ASP_2022232.Controllers
{
    public class OfferController : Controller
    {
        IFoodRequestRepository requestRepo;
        IOfferRepository offerRepo;
        private readonly UserManager<FoodUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public OfferController(IFoodRequestRepository requestRepo, IOfferRepository offerRepo, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.requestRepo = requestRepo;
            this.offerRepo = offerRepo;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(string requestId)
        {
            var foodrequest = this.requestRepo.GetOne(requestId);

            if (foodrequest != null)
            {
                OfferViewModel vm = new OfferViewModel();
                vm.FoodId = requestId;
                return View(vm);
            }
            else
            {
                return RedirectToAction(nameof(FoodRequestController.Index), "FoodRequest");
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(OfferViewModel newOffer)
        {
            FoodRequest p = this.requestRepo.GetOne(newOffer.FoodId);

            if (ModelState.IsValid)
            {
                Offer offer = new Offer()
                {

                    FoodId = newOffer.FoodId,
                    ContractorId = userManager.GetUserId(User)
                };

                this.offerRepo.Create(offer);

                return RedirectToAction(nameof(FoodRequestController.Details), "FoodRequest", new { id = newOffer.FoodId });
            }
            else { return View(newOffer); }
        }


     
    }
}
