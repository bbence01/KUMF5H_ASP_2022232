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

        public void Update(FoodRequest product)
        {
            FoodRequest old = this.GetOne(product.Id);
            old.IsDone = product.IsDone;
            old.Description = product.Description;
            old.Name = product.Name;
            this.context.SaveChanges();
        }
        /*
        public IEnumerable<FoodRequest> GetPurchasedItems(string userId)
        {
            return this.GetAll().Where(p => p.IsDone && p.HighestBid != null && p.HighestBid.ContractorId == userId);
        }*/

        public void Delete(FoodRequest product)
        {
            this.context.Foodrequests.Remove(product);
            this.context.SaveChanges();
        }
    }
}
