using CodeFirst_Annotations_Examples.Models;
using System.Data.Entity.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirst_Annotations_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BreakAwayContext>());
            InsertDestination();
            InsertTrip();
            InsertPerson();

            UpdateTrip();

            CleanExit();
        }


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
