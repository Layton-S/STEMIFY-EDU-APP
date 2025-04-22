using STEMify.Models;
using Microsoft.EntityFrameworkCore;
//using static System.Net.Mime.MediaTypeNames;

namespace STEMify.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //public DbSet<Tests> Test { get; set; }

    }
}
