using ELearn.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ELearn.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.HeadOfDepartment.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SubjectCoordinator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Lecturer.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Student.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Sponsor.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                FirstName = "Tristan",
                LastName = "Alting",
                Address = "33 Iron Str, Iron Bottom Sound",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "7");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Lecturer.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Student.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.HeadOfDepartment.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SubjectCoordinator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Sponsor.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SuperAdmin.ToString());
                }

            }
        }
    }
}
