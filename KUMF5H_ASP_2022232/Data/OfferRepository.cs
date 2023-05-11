using KUMF5H_ASP_2022232.Models;

namespace KUMF5H_ASP_2022232.Data
{
    public class OfferRepository : IOfferRepository
    {
        ApplicationDbContext context;

        public OfferRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Offer offer)
        {


            context.Offers.Add(offer);
            context.SaveChanges();
        }

        public IEnumerable<Offer> GetAll()
        {
            return context.Offers;
        }

        public Offer GetOne(string id)
        {
            return context.Offers.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Offer bid)
        {
            this.context.Offers.Remove(bid);
            this.context.SaveChanges();
        }

        public void Delete(string id)

        {
            var word = context.Offers.Find(id);
            if (word != null)
            {
                context.Offers.Remove(word);
                context.SaveChanges();
            }
        }
        public List<Offer> GetOffersForRequest(string id)
        {
            return context.Offers.Where(p => p.FoodId == id).ToList();
        }

        public void Update(Offer offer)
        {
            Offer old = this.GetOne(offer.Id);
            old.Choosen = offer.Choosen;
           
            this.context.SaveChanges();
        }

    }
}
