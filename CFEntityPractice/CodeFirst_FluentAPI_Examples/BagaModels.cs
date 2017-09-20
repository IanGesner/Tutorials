using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_FluentAPI_Examples
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public List<Lodging> Lodgings { get; set; }
    }

    public class Lodging
    {
        public int LodgingId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public bool IsResort { get; set; }

        public decimal MilesFromNearestAirport { get; set; }
        public List<InternetSpecial> InternetSpecials { get; set; }
        public Person PrimaryContact { get; set; }
        public Person SecondaryContact { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }

    public class Trip
    {
        public Guid Identifier { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CostUSD { get; set; }
        public byte[] RowVersion { get; set; }

        public List<Activity> Activities { get; set; }
    }

    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public List<Trip> Trips { get; set; }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public int SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<Lodging> PrimaryContactFor { get; set; }
        public List<Lodging> SecondaryContactFor { get; set; }

        public PersonPhoto Photo { get; set; }
    }

    public class PersonPhoto
    {
        public int PersonId { get; set; }
        public byte[] Photo { get; set; }
        public string Caption { get; set; }

        public Person PhotoOf { get; set; }
    }

    public class Address
    {
        //public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class InternetSpecial
    {
        public int InternetSpecialId { get; set; }
        public int Nights { get; set; }
        public decimal CostUSD { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int AccommodationId { get; set; }
        public Lodging Accommodation { get; set; }
    }
}
