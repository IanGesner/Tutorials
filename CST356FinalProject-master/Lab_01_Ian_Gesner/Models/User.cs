using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_01_Ian_Gesner.Models
{
    public class User
    {
        [Key]
        [Required]
        public int PersonID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public String EmailAddress { get; set; }

        [Display(Name = "Groups")]
        public virtual List<Group> Group { get; set; }
    }
}