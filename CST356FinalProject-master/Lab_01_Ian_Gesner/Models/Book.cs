using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab_01_Ian_Gesner.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int BookID { get; set; }

        [Required]
        public String Title { get; set; }

        public String Author { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
    }
}