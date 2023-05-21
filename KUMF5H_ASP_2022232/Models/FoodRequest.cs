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

        [Required]
        [StringLength(100)]
            public string Name { get; set; }

                [Required]
             [StringLength(1000)]
            [MinLength(5)]
            public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public int Payment { get; set; }

        [DefaultValue("No")]
        public string Deliveryoptions { get; set; }

        [DefaultValue(false)]
        public bool IsDone { get; set; }

        [DefaultValue(false)]
        public bool InProgress { get; set; }


        [Required]
        public byte[] Picture { get; set; }
        [Required]    
        public string PictureContentType { get; set; }

            [ForeignKey(nameof(FoodUser))]
            public string RequestorId { get; set; }



            [NotMapped]
            public virtual FoodUser Requestor { get; set; }


        [NotMapped]
        public FoodUser Contractor { get; set; }


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
