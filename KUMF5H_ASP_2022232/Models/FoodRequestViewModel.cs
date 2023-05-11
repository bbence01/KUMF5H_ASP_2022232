using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KUMF5H_ASP_2022232.Models
{
    public class FoodRequestViewModel
    {
        [StringLength(100)]
        public string Name { get; set; }


        [StringLength(1000)]
        [MinLength(5)]
        public string Description { get; set; }



        [DefaultValue(false)]
        public bool IsDone { get; set; }

        [Range(1, int.MaxValue)]
        public int Payment  {get; set; }

        public string Deliveryoptions { get; set; }
    }
}
