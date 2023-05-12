using KUMF5H_ASP_2022232.Models;

namespace KUMF5H_ASP_2022232.Data
{
    public class FoodrequestRepository : IFoodRequestRepository
    {
        ApplicationDbContext context;

        public FoodrequestRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(FoodRequest product)
        {
            context.Foodrequests.Add(product);
            context.SaveChanges();
        }

        public IEnumerable<FoodRequest> GetAll()
        {
            return context.Foodrequests.ToList();
        }

        public FoodRequest GetOne(string id)
        {
            return context.Foodrequests.FirstOrDefault(p => p.Id == id);
        }

        public void Update(FoodRequest food)
        {
            FoodRequest old = this.GetOne(food.Id);
            old.IsDone = food.IsDone;
            old.Description = food.Description;
            old.Name = food.Name;
            old.Contractor = food.Contractor;
            this.context.SaveChanges();
        }


        public void Delete(FoodRequest food)
        {
            this.context.Foodrequests.Remove(food);
            this.context.SaveChanges();
        }


        public IEnumerable<FoodRequest> SeeAcceptedOffers(string userId)
        {
            // return this.GetAll().Where(p => p.IsDone && p.Contractor != null && p.Contractor.Id == userId);

            // return this.GetAll().Where(p => p.Offers.Where(x => x.Choosen == true && x.ContractorId == userId ) );

             return this.GetAll().Where(p => p.Offers.Any(x=> x.Choosen == true && x.ContractorId == userId ) );
        }

    }
}
