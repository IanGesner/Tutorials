﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using DataAccess;
using Model;
using System.Data.Objects.DataClasses;

namespace BreakAwayConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new InitializeBagaDatabaseWithSeedData());

            //AddMachuPicchu();
            //ChangeGrandCanyon();
            //DeleteWineGlassBay();

            //DeleteTrip();
            //DeleteGrandCanyon();

            //MakeMultipleChanges();
            FindOrAddPerson();

            //QueryLodgingCount();
        }

        private static void NewGrandCanyonResort()
        {
            using (var context = new BreakAwayContext())
            {
                var resort = new Resort
                {
                    Name = "Pete's Luxury Resort"
                };

                context.Lodgings.Add(resort);

                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                canyon.Lodgings.Add(resort);

                context.SaveChanges();
            }
        }

        private static void FindOrAddPerson()
        {
            using (var context = new BreakAwayContext())
            {
                var ssn = 123456789;

                var person = context.People.Find(ssn)
                  ?? context.People.Add(new Person
                  {
                      SocialSecurityNumber = ssn,
                      FirstName = "<enter first name>",
                      LastName = "<enter last name>"
                  });

                Console.WriteLine(person.FirstName);
            }
        }

        private static void MakeMultipleChanges()
        {
            using (var context = new BreakAwayContext())
            {
                var niagaraFalls = new Destination
                {
                    Name = "Niagara Falls",
                    Country = "USA"
                };

                context.Destinations.Add(niagaraFalls);

                var wineGlassBay = (from d in context.Destinations
                                    where d.Name == "Wine Glass Bay"
                                    select d).Single();

                wineGlassBay.Description = "Picturesque bay with beaches.";

                context.SaveChanges();
            }
        }

        private static void DeleteGrandCanyon()
        {
            using (var context = new BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                context.Destinations.Remove(canyon);
                context.SaveChanges();
            }
        }

        private static void DeleteTrip()
        {
            using (var context = new BreakAwayContext())
            {
                var trip = (from t in context.Trips
                            where t.Description == "Trip from the database"
                            select t).Single();


                var res = (from r in context.Reservations
                           where r.Trip.Description == "Trip from the database"
                           select r).Single();


                context.Trips.Remove(trip);
                context.SaveChanges();
            }
        }

        private static void DeleteWineGlassBay()
        {
            using (var context = new BreakAwayContext())
            {
                var bay = (from d in context.Destinations
                           where d.Name == "Wine Glass Bay"
                           select d).Single();

                context.Destinations.Remove(bay);
                context.SaveChanges();
            }

            //better way
            //var toDelete = new Destination { DestinationId = 2 };
            //context.Destinations.Attach(toDelete);
            //context.Destinations.Remove(toDelete);
            //context.SaveChanges();
        }

        private static void AddMachuPicchu()
        {
            using (var context = new BreakAwayContext())
            {
                var machuPicchu = new Destination
                {
                    Name = "Machu Picchu",
                    Country = "Peru"
                };

                context.Destinations.Add(machuPicchu);
                context.SaveChanges();
            }
        }

        private static void ChangeGrandCanyon()
        {
            using (var context = new BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                canyon.Description = "227 mile long canyon.";

                context.SaveChanges();
            }
        }

        private static void PrintAllDestinations()
        {
            using (var context = new BreakAwayContext())
            {
                foreach (var destination in context.Destinations)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        private static void PrintAllDestinationsTwice()
        {
            using (var context = new BreakAwayContext())
            {
                var allDestinations = context.Destinations.ToList();

                foreach (var destination in allDestinations)
                {
                    Console.WriteLine(destination.Name);
                }
                foreach (var destination in allDestinations)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        private static void PrintAllDestinationsSorted()
        {
            using (var context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            orderby d.Name
                            select d;

                foreach (var destination in query)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        private static void PrintAustralianDestinations()
        {
            using (var context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Country == "Australia"
                            select d;

                foreach (var destination in query)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        private static void PrintDestinationNameOnly()
        {
            using (var context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Country == "Australia"
                            orderby d.Name
                            select d.Name;

                foreach (var name in query)
                {
                    Console.WriteLine(name);
                }
            }
        }

        private static void FindDestination()
        {
            Console.Write("Enter id of Destination to find: ");
            var id = int.Parse(Console.ReadLine());

            using (var context = new BreakAwayContext())
            {
                var destination = context.Destinations.Find(id);

                if (destination == null)
                {
                    Console.WriteLine("Destination not found!");
                }
                else
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        private static void FindGreatBarrierReef()
        {
            using (var context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Name == "Great Barrier Reef"
                            select d;

                var reef = query.SingleOrDefault();

                if (reef == null)
                {
                    Console.WriteLine("Can't find the reef!");
                }
                else
                {
                    Console.WriteLine(reef.Description);
                }
            }
        }

        private static void GetLocalDestinationCount()
        {
            using (var context = new BreakAwayContext())
            {
                foreach (var destination in context.Destinations)
                {
                    Console.WriteLine(destination.Name);
                }

                var count = context.Destinations.Local.Count;
                Console.WriteLine("Destinations in memory: {0}", count);
            }
        }

        private static void GetLocalDestinationCountWithLoad()
        {
            using (var context = new BreakAwayContext())
            {
                context.Destinations.Load();
                var count = context.Destinations.Local.Count;
                Console.WriteLine("Destinations in memory: {0}", count);
            }
        }

        private static void LoadAustralianDestinations()
        {
            using (var context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Country == "Australia"
                            select d;

                query.Load();
                var count = context.Destinations.Local.Count;
                Console.WriteLine("Aussie destinations in memory: {0}", count);
            }
        }

        private static void LocalLinqQueries()
        {
            using (var context = new BreakAwayContext())
            {
                context.Destinations.Load();

                var sortedDestinations = from d in context.Destinations.Local
                                         orderby d.Name
                                         select d;

                Console.WriteLine("All Destinations:");
                foreach (var destination in sortedDestinations)
                {
                    Console.WriteLine(destination.Name);
                }

                var aussieDestinations = from d in context.Destinations.Local
                                         where d.Country == "Australia"
                                         select d;

                Console.WriteLine();
                Console.WriteLine("Australian Destinations:");
                foreach (var destination in aussieDestinations)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        private static void ListenToLocalChanges()
        {
            using (var context = new BreakAwayContext())
            {
                context.Destinations.Local.CollectionChanged += (sender, args) =>
                {
                    if (args.NewItems != null)
                    {
                        foreach (Destination item in args.NewItems)
                        {
                            Console.WriteLine("Added: " + item.Name);
                        }
                    }

                    if (args.OldItems != null)
                    {
                        foreach (Destination item in args.OldItems)
                        {
                            Console.WriteLine("Removed: " + item.Name);
                        }
                    }
                };

                context.Destinations.Load();
            }
        }

        private static void TestLazyLoading()
        {
            using (var context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Name == "Grand Canyon"
                            select d;

                var canyon = query.Single();

                Console.WriteLine("Grand Canyon Lodging:");
                if (canyon.Lodgings != null)
                {
                    foreach (var lodging in canyon.Lodgings)
                    {
                        Console.WriteLine(lodging.Name);
                    }
                }
            }
        }

        private static void TestEagerLoading()
        {
            using (var context = new BreakAwayContext())
            {
                var allDestinations = context.Destinations.Include(d => d.Lodgings);

                foreach (var destination in allDestinations)
                {
                    Console.WriteLine(destination.Name);

                    foreach (var lodging in destination.Lodgings)
                    {
                        Console.WriteLine(" - " + lodging.Name);
                    }
                }
            }
        }

        private static void TestExplicitLoading()
        {
            using (var context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Name == "Grand Canyon"
                            select d;

                var canyon = query.Single();

                context.Entry(canyon)
                  .Collection(d => d.Lodgings)
                  .Load();

                Console.WriteLine("Grand Canyon Lodging:");
                foreach (var lodging in canyon.Lodgings)
                {
                    Console.WriteLine(lodging.Name);
                }
            }
        }

        private static void TestIsLoaded()
        {
            using (var context = new BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                var entry = context.Entry(canyon);

                Console.WriteLine("Before Load: {0}", entry.Collection(d => d.Lodgings).IsLoaded);

                entry.Collection(d => d.Lodgings).Load();
                Console.WriteLine("After Load: {0}", entry.Collection(d => d.Lodgings).IsLoaded);
            }
        }

        private static void QueryLodgingDistance()
        {
            using (var context = new BreakAwayContext())
            {
                var canyonQuery = from d in context.Destinations
                                  where d.Name == "Grand Canyon"
                                  select d;

                var canyon = canyonQuery.Single();

                var lodgingQuery = context.Entry(canyon)
                  .Collection(d => d.Lodgings)
                  .Query();

                var distanceQuery = from l in lodgingQuery
                                    where l.MilesFromNearestAirport <= 10
                                    select l;

                foreach (var lodging in distanceQuery)
                {
                    Console.WriteLine(lodging.Name);
                }
            }
        }

        private static void QueryLodgingCount()
        {
            using (var context = new BreakAwayContext())
            {
                var canyonQuery = from d in context.Destinations
                                  where d.Name == "Grand Canyon"
                                  select d;

                var canyon = canyonQuery.Single();

                var lodgingQuery = context.Entry(canyon)
                  .Collection(d => d.Lodgings)
                  .Query();

                var lodgingCount = lodgingQuery.Count();
                Console.WriteLine("Lodging at Grand Canyon: " + lodgingCount);
            }
        }
    }
}
