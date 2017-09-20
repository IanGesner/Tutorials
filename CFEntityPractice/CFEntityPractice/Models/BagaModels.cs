using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_Annotations_Examples.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(6)]
        public string Country { get; set; }

        [MaxLength(500)]
        [MinLength(10)]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public List<Lodging> Lodgings { get; set; }
    }

    public class Lodging
    {
        public int LodgingId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public bool IsResort { get; set; }

        public Destination Destination { get; set; }
    }

    public class Trip
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Identifier { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CostUSD { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public class Person
    {
        public int PersonId { get; set; }

        [ConcurrencyCheck]
        public int SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }

    [ComplexType]
    public class Address
    {
        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
