using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab_01_Ian_Gesner.Models
{
    public class Group
    {
        [Key]
        [Required]
        public int GroupID { get; set; }

        [Required]
        public String Name { get; set; }

        public virtual List<User> Users { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
    }
}