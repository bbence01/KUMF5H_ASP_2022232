using KUMF5H_ASP_2022232.Models;

namespace KUMF5H_ASP_2022232.Data
{
    public interface IOfferRepository
    {
        void Create(Offer offer);
        void Delete(Offer offer);
        void Delete(string id);
        IEnumerable<Offer> GetAll();
        Offer GetOne(string id);

        List<Offer> GetOffersForRequest(string id);

        void Update(Offer offer);
    }
}
