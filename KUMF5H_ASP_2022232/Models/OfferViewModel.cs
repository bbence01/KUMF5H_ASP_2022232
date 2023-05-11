using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUMF5H_ASP_2022232.Models
{
    public class OfferViewModel
    {


        public bool Choosen { get; set; }





        [ForeignKey(nameof(Models.FoodRequest))]
        public string FoodId { get; set; }

     

    }
}
