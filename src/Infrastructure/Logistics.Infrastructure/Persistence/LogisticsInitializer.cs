using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.Infrastructure.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Logistics.Infrastructure.Persistence
{
   public class LogisticsInitializer
    {

       
        private readonly Dictionary<int, Category> Categories = new Dictionary<int, Category>();
        private readonly Dictionary<int, Shipper> Shippers = new Dictionary<int, Shipper>();
      

        public static void Initialize(LogisticsDbContext context, IServiceProvider serviceProvider)
        {
          
            var initializer = new LogisticsInitializer();
           
            initializer.SeedEverything(context, serviceProvider);
        }

        public void SeedEverything(LogisticsDbContext context, IServiceProvider serviceProvider)
        {
          

           
            //New code introduced
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var ctx = provider.GetRequiredService<LogisticsDbContext>();
                var userManager = provider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

                // automigration 
               // context.Database.EnsureCreated();
                ctx.Database.Migrate();
                InstallUsers(userManager, roleManager);
            }

            //End New Code

          



         


        }



        public static void InstallUsers(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string USERNAME = "admin@loadboard.com";
            const string PASSWORD = "123456ABCD";
            const string ROLENAME = "Admin";
            //foreach (var role in Enum.GetNames(typeof(Roles)))
            //{

            //}
                var roleExist = roleManager.RoleExistsAsync(ROLENAME).Result;
            if (!roleExist)
            {
                //create the roles and seed them to the database
                roleManager.CreateAsync(new IdentityRole(ROLENAME)).GetAwaiter().GetResult();
            }

            var user = userManager.FindByNameAsync(USERNAME).Result;

            if (user == null)
            {
                var serviceUser = new AppUser
                {
                    UserName = USERNAME,
                    Email = USERNAME
                };

                var createPowerUser = userManager.CreateAsync(serviceUser, PASSWORD).Result;
                if (createPowerUser.Succeeded)
                {
                   // var confirmationToken = userManager.GenerateEmailConfirmationTokenAsync(serviceUser).Result;
                   // var result = userManager.ConfirmEmailAsync(serviceUser, confirmationToken).Result;
                    //here we tie the new user to the role
                    userManager.AddToRoleAsync(serviceUser, ROLENAME).GetAwaiter().GetResult();
                }
            }
        }
        //private void SeedRegions(Logistics.InfrastructureContextDb context)
        //{
        //    var regions = new[]
        //    {
        //        new Region { RegionId = 1, RegionDescription = "Eastern"},
        //        new Region { RegionId = 2, RegionDescription = "Western"},
        //        new Region { RegionId = 3, RegionDescription = "Northern"},
        //        new Region { RegionId = 4, RegionDescription = "Southern"}
        //    };

        //    context.Region.AddRange(regions);

        //    context.SaveChanges();
        //}

    }
}
