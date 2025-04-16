using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace STEMify.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //// Seed roles here or in SeedData.cs
            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            //    new IdentityRole { Name = "User", NormalizedName = "USER" },
            //    new IdentityRole { Name = "Teacher", NormalizedName = "TEACHER" },
            //    new IdentityRole { Name = "Student", NormalizedName = "STUDENT" }
            //);
        }
    
    }
}
