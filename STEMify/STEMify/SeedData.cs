using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace STEMify.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string adminPassword,
                                         string userPassword = "UserPassword123!")
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

                try
                {
                    // 1. Seed Roles
                    await SeedRoles(roleManager);

                    // 2. Seed Admin User
                    await SeedAdminUser(userManager, adminPassword);

                    // 3. Seed Regular User
                    await SeedRegularUser(userManager, userPassword);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database");
                    throw;
                }
            }
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User", "Editor" }; // Add other roles as needed

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        private static async Task SeedAdminUser(UserManager<IdentityUser> userManager, string password)
        {
            var adminUser = new IdentityUser
            {
                UserName = "admin@stemify.com",
                Email = "admin@stemify.com",
                EmailConfirmed = true
            };

            if (await userManager.FindByEmailAsync(adminUser.Email) == null)
            {
                var result = await userManager.CreateAsync(adminUser, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    // Optionally add to other roles
                    await userManager.AddToRoleAsync(adminUser, "User");
                }
            }
        }

        private static async Task SeedRegularUser(UserManager<IdentityUser> userManager, string password)
        {
            var regularUser = new IdentityUser
            {
                UserName = "user@stemify.com",
                Email = "user@stemify.com",
                EmailConfirmed = true
            };

            if (await userManager.FindByEmailAsync(regularUser.Email) == null)
            {
                var result = await userManager.CreateAsync(regularUser, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(regularUser, "User");
                }
            }
        }
    }
}