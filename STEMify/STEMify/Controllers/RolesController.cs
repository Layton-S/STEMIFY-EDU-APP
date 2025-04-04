using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
public class RolesController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    public RolesController(RoleManager<IdentityRole> roleManager,
        UserManager<IdentityUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var roles = _roleManager.Roles;
        return View(roles);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(IdentityRole model)
    {
        if (!await _roleManager.RoleExistsAsync(model.Name))
        {
            await _roleManager.CreateAsync(new IdentityRole(model.Name));
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Assign()
    {
        ViewBag.Users = _userManager.Users.ToList();
        ViewBag.Roles = _roleManager.Roles.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Assign(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.AddToRoleAsync(user, roleName);
        return RedirectToAction("Index");
    }
}
