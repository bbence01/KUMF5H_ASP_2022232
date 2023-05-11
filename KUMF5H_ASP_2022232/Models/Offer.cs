using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KUMF5H_ASP_2022232.Models
{
    public class Offer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }


        public bool Choosen { get; set; }





        [ForeignKey(nameof(Models.FoodRequest))]
        public string FoodId { get; set; }

        [ForeignKey(nameof(Models.FoodUser))]
        public string ContractorId { get; set; }





        [NotMapped]
        [JsonIgnore]
        [ValidateNever]

        public virtual FoodRequest Request { get; set; }

        [JsonIgnore]
        [ValidateNever]
        [NotMapped]
        public virtual FoodUser User { get; set; }

        public Offer()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
