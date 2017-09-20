namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OdeToFood.Models;
    using System.Collections.Generic;
    using System.Web.Security;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                                            new Restaurant { Name = "Sabatino's", City = "Baltimore", Country = "USA" },
                                            new Restaurant
                                            {
                                                Name = "Smaka",
                                                City = "Gothenburg",
                                                Country = "Sweden",
                                                Reviews = new List<RestaurantReview>
                                                            {
                                                                        new RestaurantReview
                                                                        {
                                                                            Rating =9, Body="Great food!", Name="Ted"
                                                                        }
                                                            }

                                            });

            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant { Name = i.ToString(), City = "Nowhere", Country = "USA" });
            }

            //SeedMembership(); // it doesn't work
            SeedMembershipMVCFive(context);
        }

        private void SeedMembershipMVCFive(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "gesner.ian@gmail.com";
                user.Email = "gesner.ian@gmail.com";

                string userPWD = "P@ssword123";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }
        }

        //private void SeedMembership()
        //{
        //    var roles = Roles.Provider;
        //    MembershipProvider membership = Membership.Provider;
        //    MembershipCreateStatus createStatus;

        //    if (!roles.RoleExists("Admin"))
        //        roles.CreateRole("Admin");

        //    if (membership.GetUser("sallen", false) == null)
        //    {
        //        membership.CreateUser("sallen", "password123", "stolemine@gmail.com", "Who's your favorite person to steal online aliases from?", "Ian Gesner", true, null, out createStatus);
        //        if (createStatus.HasFlag(MembershipCreateStatus.UserRejected | MembershipCreateStatus.ProviderError))
        //            throw new Exception("Membership.CreateUser() failed with MembershipCreateStatus." + createStatus.ToString());
        //    }

        //    if (!roles.GetRolesForUser("sallen").Contains("Admin"))
        //        roles.AddUsersToRoles(new[] { "sallen" }, new[] { "Admin" });


        //}
    }
}

