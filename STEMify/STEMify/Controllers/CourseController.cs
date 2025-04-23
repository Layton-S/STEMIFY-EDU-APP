using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Controllers
{

    public class CourseController : BaseController
    {
        public CourseController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ActionResult Index()
        {
            var courses = UnitOfWork.Courses.GetAll().ToList();
            return View(courses);
        }

        public IActionResult DifficultyLevels()
        {
            var levels = UnitOfWork.DifficultyLevels.GetAll().ToList();
            return View(levels);
        }
        public IActionResult Categories()
        {
            var MODEL = UnitOfWork.Categories.GetAll().ToList();
            return View(MODEL);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(UnitOfWork.Categories.GetAll(), "CategoryID", "CategoryName");
            ViewBag.DifficultyLevels = new SelectList(UnitOfWork.DifficultyLevels.GetAll(), "DifficultyLevelID", "LevelName");
            return View();
        }
        public IActionResult CreateCategory()
        {
            ViewBag.Categories = new SelectList(UnitOfWork.Categories.GetAll(), "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category model)
        {
            if(ModelState.IsValid)
            {
                UnitOfWork.Categories.Add(model);
                UnitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public IActionResult CreateDifficultyLevels()
        {
            //ViewBag.DifficultyLevels = new SelectList(UnitOfWork.DifficultyLevels.GetAll(), "DifficultyLevelID", "LevelName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateDifficultyLevels(DifficultyLevel model)
        {
            if(ModelState.IsValid)
            {
                UnitOfWork.DifficultyLevels.Add(model);
                UnitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Course course)
        {                
            // Auto-generate CourseCode based on CategoryID and timestamp
            var category = UnitOfWork.Categories.Get(course.CategoryID);
            var categoryPrefix = category.CategoryName.Substring(0, 4).ToUpper();
            course.CourseCode = $"CRS-{categoryPrefix}";
            ModelState.Remove("CourseCode");
            if(ModelState.IsValid)
            {


                course.CreatedAt = DateTime.UtcNow;
                course.LastUpdated = DateTime.UtcNow;
                course.IsActive = true;

                UnitOfWork.Courses.Add(course);
                await UnitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }

            // Repopulate dropdowns if validation fails
            ViewBag.Categories = new SelectList(UnitOfWork.Categories.GetAll(), "CategoryID", "CategoryName", course.CategoryID);
            ViewBag.DifficultyLevels = new SelectList(UnitOfWork.DifficultyLevels.GetAll(), "DifficultyLevelID", "LevelName", course.DifficultyLevelID);

            return View(course);
        }


    }

}
