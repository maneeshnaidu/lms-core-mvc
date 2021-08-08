using LeaveManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.RolesEnum.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.RolesEnum.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.RolesEnum.Employee.ToString()));            

        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@localhost.com",
                FirstName = "Super",
                LastName = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.RolesEnum.Employee.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.RolesEnum.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.RolesEnum.SuperAdmin.ToString());
                }

            }
        }

        
    }
}
