using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace CodeFirst_FluentAPI_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BreakAwayContext>());

            try
            {
                InsertDestination();
                //InsertTrip();
                InsertPerson();

                //DeleteDestinationInMemoryAndDbCascade();

                //DeleteDestinationInMemoryAndDbCascadeWithoutEagerLoading();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            CleanExit();
        }

        //private static void DeleteDestinationInMemoryAndDbCascade()
        //{
        //    int destinationId;
        //    using (var context = new BreakAwayContext())
        //    {
        //        var destination = new Destination
        //        {
        //            Name = "Sample Destination", Country = "USA",
        //            Lodgings = new List<Lodging>()
        //            {
        //                new Lodging { Name = "Lodging One" },
        //                new Lodging { Name = "Lodging Two" }
        //            }
        //        };

        //        context.Destinations.Add(destination);
        //        context.SaveChanges();
        //        destinationId = destination.DestinationId;
        //    }

        //    using (var context = new BreakAwayContext())
        //    {
        //        var destination = context.Destinations
        //          .Include("Lodgings")
        //          .Single(d => d.DestinationId == destinationId);

        //        var aLodging = destination.Lodgings.FirstOrDefault();
        //        context.Destinations.Remove(destination);

        //        Console.WriteLine("State of one Lodging: {0}",
        //          context.Entry(aLodging).State.ToString());

        //        context.SaveChanges();
        //    }
        //}

        //private static void DeleteDestinationInMemoryAndDbCascadeWithoutEagerLoading()
        //{
        //    int destinationId;
        //    using (var context = new BreakAwayContext())
        //    {
        //        var destination = new Destination
        //        {
        //            Name = "Sample Destination",
        //            Country = "USA",
        //            Lodgings = new List<Lodging>
        //            {
        //            new Lodging { Name = "Lodging One" },
        //            new Lodging { Name = "Lodging Two" }
        //            }
        //        };

        //        context.Destinations.Add(destination);
        //        context.SaveChanges();
        //        destinationId = destination.DestinationId;
        //    }

        //    using (var context = new BreakAwayContext())
        //    {
        //        var destination = context.Destinations
        //          .Single(d => d.DestinationId == destinationId);

        //        context.Destinations.Remove(destination);
        //        context.SaveChanges();
        //    }

        //    using (var context = new BreakAwayContext())
        //    {
        //        var lodgings = context.Lodgings
        //          .Where(l => l.DestinationId == destinationId).ToList();

        //        Console.WriteLine("Lodgings: {0}", lodgings.Count);
        //    }
        //}



        private static void InsertDestination()
        {
            var destination = new Destination
            {
                Country = "Indonesia",
                Description = "EcoTourism at its best in exquisite Bali",
                Name = "Bali"
            };
            using (var context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);
                context.SaveChanges();
            }
        }

        private static void InsertTrip()
        {
            var trip = new Trip { CostUSD = 800, StartDate = new DateTime(2011, 9, 1), EndDate = new DateTime(2011, 9, 14) };

            using (var context = new BreakAwayContext())
            {
                context.Trips.Add(trip);
                context.SaveChanges();
            }
        }

        private static void InsertPerson()
        {
            var person = new Person
            {
                FirstName = "Rowan",
                LastName = "Miller",
                SocialSecurityNumber = 12345678,
                Address = new Address()
            };
            using (var context = new BreakAwayContext())
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }

        private static void UpdateTrip()
        {
            using (var context = new BreakAwayContext())
            {
                var trip = context.Trips.FirstOrDefault();
                trip.CostUSD = 750;
                context.SaveChanges();
            }
        }


        //This is a helper function to avoid needing to delete
        //databases from Management Studio or Server Explorer
        //all the time.
        private static void CleanExit()
        {
            Console.WriteLine("Press R to remove the database. Press any key to exit.");
            ConsoleKeyInfo key = Console.ReadKey();

            try
            {
                if (key.KeyChar == 'r' || key.KeyChar == 'R')
                {
                    using (var context = new BreakAwayContext())
                    {
                        context.Database.Delete();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                if (e.Number == 3702)
                {
                    Console.Clear();
                    Console.WriteLine("\nThe database connection was in use by another program. Please close connections and try again.\n");
                    CleanExit();
                }
            }
        }
    }
}
