using CodeFirst_Annotations_Examples.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_Annotations_Examples
{
    class BreakAwayContext : DbContext
    {
        public BreakAwayContext() { }
        
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
