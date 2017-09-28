using Lab_01_Ian_Gesner.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lab_01_Ian_Gesner.Data
{
    public class DatabaseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DatabaseContext() : base("name=DataContext")
        {
        }

        //        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //        {
        //            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //        }

        public System.Data.Entity.DbSet<User> User { get; set; }

        public System.Data.Entity.DbSet<Group> Groups { get; set; }
    }
}
