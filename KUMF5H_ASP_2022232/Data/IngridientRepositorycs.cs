using KUMF5H_ASP_2022232.Models;

namespace KUMF5H_ASP_2022232.Data
{
    public class IngridientRepository : IingridientRepository
    {
        ApplicationDbContext context;

        public IngridientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Ingredient c)
        {
            context.Ingredients.Add(c);
            context.SaveChanges();
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return context.Ingredients;
        }

        public Ingredient GetOne(string id)
        {
            return context.Ingredients.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Ingredient c)
        {
            this.context.Ingredients.Remove(c);
            this.context.SaveChanges();
        }

        public void Delete(string id)

        {
            var word = context.Ingredients.Find(id);
            if (word != null)
            {
                context.Ingredients.Remove(word);
                context.SaveChanges();
            }
        }

        public List<Ingredient> GetIngredientsForRequest(string id)
        {
            return context.Ingredients.Where(p => p.FoodId == id).ToList();
        }
    }
}
