using OdeToFood.Models.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantReview : IValidatableObject
    {
        private readonly string[] IGNORED_NAMES = { "Ian", "Fred" };
        public int Id { get; set; }

        [MaxWords(2, ErrorMessage = "custom")]
        public string Name { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }

        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }
        public int RestaurantId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var name in IGNORED_NAMES)
            {
                if (Rating < 5 && Name.ToLower() == name.ToLower())
                    yield return new ValidationResult($"Go away, {name}");
            }
        }
    }
}