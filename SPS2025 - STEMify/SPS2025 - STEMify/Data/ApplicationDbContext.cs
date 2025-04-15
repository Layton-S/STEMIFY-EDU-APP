using Microsoft.EntityFrameworkCore;

namespace SPS2025___STEMify.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed admin account
            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 1, Username = "Admin_00", Password = "Admin2025" }
            );
        }
    }
}