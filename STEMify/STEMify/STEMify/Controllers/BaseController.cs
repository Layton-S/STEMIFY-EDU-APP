using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;

namespace STEMify.Controllers
{
    // BaseController.cs
    public class BaseController : Controller
    {
        public readonly IUnitOfWork UnitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}