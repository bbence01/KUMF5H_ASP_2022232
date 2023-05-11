using KUMF5H_ASP_2022232.Models;
using Microsoft.EntityFrameworkCore;

namespace KUMF5H_ASP_2022232.Data
{
    public class FoodUserRepository : IFoodUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FoodUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<FoodUser> GetAllFoodusers()
        {
            return _dbContext.Users.ToList();
        }

        public FoodUser GetFooduserById(string FoodUserid)
        {
            return _dbContext.Users.Find(FoodUserid);
        }

        public FoodUser CreateFooduser(FoodUser foodUser)
        {
            _dbContext.Users.Add(foodUser);
            _dbContext.SaveChanges();
            return foodUser;
        }

        public FoodUser UpdateFooduser(FoodUser foodUser)
        {
            _dbContext.Entry(foodUser).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return foodUser;
        }

        public void DeleteFooduser(string foodUserId)
        {
            var foodUser = _dbContext.Users.Find(foodUserId);
            if (foodUser != null)
            {
                _dbContext.Users.Remove(foodUser);
                _dbContext.SaveChanges();
            }
        }

        public void AddRange(List<FoodUser> foodUsers)
        {
            _dbContext.AddRange(foodUsers);
            _dbContext.SaveChanges();
        }
    }
}
