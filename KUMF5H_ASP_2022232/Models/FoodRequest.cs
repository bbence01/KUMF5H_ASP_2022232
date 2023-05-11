using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace KUMF5H_ASP_2022232.Models


{
    public class FoodRequest
    {

       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string Id { get; set; }


            [StringLength(100)]
            public string Name { get; set; }


            [StringLength(1000)]
            [MinLength(5)]
            public string Description { get; set; }



            [DefaultValue(false)]
            public bool IsDone { get; set; }

            [NotMapped]
            public byte[] Picture { get; set; }

            public string PictureContentType { get; set; }

            [ForeignKey(nameof(FoodUser))]
            public string RequestorId { get; set; }



            [NotMapped]
            public virtual FoodUser Requestor { get; set; }


        [NotMapped]
        [JsonIgnore]
        [ValidateNever]

        public virtual List<Ingredient> Ingridients { get; set; }

        [NotMapped]
            [JsonIgnore]
            [ValidateNever]
            public virtual List<Offer> Offers { get; set; }

            [NotMapped]
            [JsonIgnore]
            [ValidateNever]
            public virtual List<Comment> Comments { get; set; }


            public FoodRequest()
            {
                this.Id = Guid.NewGuid().ToString();
            }
        

    }
}
