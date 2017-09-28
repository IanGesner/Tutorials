using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab_01_Ian_Gesner.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public String Title { get; set; }

        public String Director { get; set; }

        public String Genre { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
    }
}