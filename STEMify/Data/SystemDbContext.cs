using Microsoft.EntityFrameworkCore;

namespace STEMify.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options)
            : base(options)
        {
        }

        // Example DbSet
        //public DbSet<Courses> SystemSettings { get; set; }
    }
}
