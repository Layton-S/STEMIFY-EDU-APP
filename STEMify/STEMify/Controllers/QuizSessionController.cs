using Microsoft.AspNetCore.Mvc;
using STEMify.Data;
using STEMify.Data.Interfaces;
using STEMify.Data.Repositories;

namespace STEMify.Controllers
{
    public class QuizSessionController : BaseController
    {
        public QuizSessionController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
