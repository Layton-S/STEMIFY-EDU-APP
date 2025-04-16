// In Data/SeedData.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace STEMify.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string adminPassword)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Ensure the database is created and migrated
            await context.Database.MigrateAsync();

            // Seed roles
            string[] roleNames = { "Admin", "User", "Teacher", "Student" };
            foreach(var roleName in roleNames)
            {
                if(!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Seed admin user
            var adminEmail = "admin@stemify.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if(adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}