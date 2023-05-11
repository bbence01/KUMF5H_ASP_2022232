using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace KUMF5H_ASP_2022232.Models
{
    public class FoodUser : IdentityUser
    {

        public string FoodUserName { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }



        [NotMapped]
        [JsonIgnore]
        [ValidateNever]
        public virtual List<FoodRequest> FoodRequests { get; set; }

        [NotMapped]
        [JsonIgnore]
        [ValidateNever]
        public virtual List<Offer> Offers { get; set; }

        [NotMapped]
        [JsonIgnore]
        [ValidateNever]
        public virtual List<Comment> Comments { get; set; }
    }
}
