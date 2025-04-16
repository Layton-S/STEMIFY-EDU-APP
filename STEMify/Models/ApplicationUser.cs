// In Models/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;

namespace STEMify.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add additional properties here if needed
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}