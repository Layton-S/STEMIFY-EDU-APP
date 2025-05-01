using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STEMify.Models;
using STEMify.Data.Interfaces;

namespace STEMify.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        //[Authorize]

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard() 
        {
            return View();
        }

        //[Authorize]
        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
