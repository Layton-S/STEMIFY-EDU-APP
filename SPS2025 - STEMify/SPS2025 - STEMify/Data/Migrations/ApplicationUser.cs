using Microsoft.AspNetCore.Identity;

namespace SPS2025___STEMify.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
