using KUMF5H_ASP_2022232.Models;

namespace KUMF5H_ASP_2022232.Data
{
    public interface IFoodRequestRepository
    {
        void Create(FoodRequest foodrequest);
        void Delete(FoodRequest foodrequest);
        IEnumerable<FoodRequest> GetAll();
        FoodRequest GetOne(string id);
        void Update(FoodRequest foodrequest);
        //    IEnumerable<FoodRequest> GetPurchasedItems(string userId);
    }
}
