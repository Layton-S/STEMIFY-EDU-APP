// In Controllers/UsersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEMify.Controllers
{
    [Authorize(Roles = "Admin")] // Restrict to Admins only
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Users
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // GET: Users/ManageRoles/5
        public async Task<IActionResult> ManageRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }

            var model = new List<UserRoleViewModel>();
            foreach(var role in _roleManager.Roles.ToList())
            {
                model.Add(new UserRoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name)
                });
            }

            ViewBag.UserId = id;
            ViewBag.UserEmail = user.Email;
            return View(model);
        }

        // POST: Users/ManageRoles/5
        [HttpPost]
        public async Task<IActionResult> ManageRoles(List<UserRoleViewModel> model, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);

            await _userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            return RedirectToAction(nameof(Index));
        }
    }

    public class UserRoleViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}