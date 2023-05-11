using KUMF5H_ASP_2022232.Models;

namespace KUMF5H_ASP_2022232.Data
{
    public interface IFoodUserRepository
    {
        FoodUser CreateFooduser(FoodUser foodUser);
        void DeleteFooduser(string foodUserid);
        IEnumerable<FoodUser> GetAllFoodusers();
        FoodUser GetFooduserById(string foodUserid);
        FoodUser UpdateFooduser(FoodUser foodUser);
        void AddRange(List<FoodUser> foodUsers);
    }
}
