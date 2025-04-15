using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPS2025___STEMify.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SPS2025___STEMify.Pages.Accounts
{
    public class AdminLogModel : PageModel
    {
        private readonly AdminAuthService _adminService;

        public AdminLogModel(AdminAuthService adminService)
        {
            _adminService = adminService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var admin = await _adminService.Authenticate(Input.Username, Input.Password);
            if (admin == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid admin credentials");
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Name, admin.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect(Url.Content("~/Admin/Dashboard"));
        }
    }
}