using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_FluentAPI_Examples
{
    class BreakAwayContext : DbContext
    {
        public BreakAwayContext() { } // Just use default DB location
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DestinationConfiguration());
            modelBuilder.Configurations.Add(new LodgingConfiguration());
            modelBuilder.Configurations.Add(new TripConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new InternetSpecialConfiguration());
            modelBuilder.Configurations.Add(new PersonPhotoConfiguration());

            modelBuilder.ComplexType<Address>();
        }
    }

    class DestinationConfiguration : EntityTypeConfiguration<Destination>
    {
        public DestinationConfiguration()
        {
            Property(p => p.Name)
                .IsRequired();

            Property(p => p.Country)
                .IsRequired();

            Property(p => p.Description)
                .HasMaxLength(500);

            Property(p => p.Photo)
                .HasColumnType("image");

        }
    }

    class LodgingConfiguration : EntityTypeConfiguration<Lodging>
    {
        public LodgingConfiguration()
        {
            Property(l => l.Name).IsRequired()
                .HasMaxLength(200);

            Property(l => l.MilesFromNearestAirport)
                .HasPrecision(8, 1);

            HasOptional(l => l.PrimaryContact)
                .WithMany(p => p.PrimaryContactFor);

            HasOptional(l => l.SecondaryContact)
                .WithMany(p => p.SecondaryContactFor);
        }
    }

    class TripConfiguration : EntityTypeConfiguration<Trip>
    {
        public TripConfiguration()
        {
            HasKey(t => t.Identifier)
                .Property(t => t.Identifier)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.RowVersion)
                .IsRowVersion();
        }
    }

    class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            HasKey(p => p.PersonId);

            //Property(p => p.SocialSecurityNumber).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //Property(p => p.RowVersion).IsRowVersion();

            Property(p => p.SocialSecurityNumber)
                .IsConcurrencyToken();

        }
    }

    class PersonPhotoConfiguration : EntityTypeConfiguration<PersonPhoto>
    {
        public PersonPhotoConfiguration()
        {
            HasKey(p => p.PersonId);

            HasRequired(p => p.PhotoOf)
                .WithRequiredDependent(p => p.Photo);
        }
    }

    class AddressConfiguration : ComplexTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            Property(a => a.StreetAddress)
                .HasMaxLength(150);
        }
    }

    class InternetSpecialConfiguration : EntityTypeConfiguration<InternetSpecial>
    {
        public InternetSpecialConfiguration()
        {
            HasRequired(i => i.Accommodation)
                .WithMany(l => l.InternetSpecials)
                .HasForeignKey(i => i.AccommodationId);
        }
    }

    class ActivityConfiguration : EntityTypeConfiguration<Activity>
    {
        public ActivityConfiguration()
        {
            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
