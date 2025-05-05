using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STEMify.Models;
using STEMify.Data.Interfaces;
using STEMify.Models.User;

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

        [Authorize]
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

        public ActionResult Courses()
        {
            var AvailableCourses = UnitOfWork.Courses.GetAll().ToList();
            return View("AvailableCourses", AvailableCourses);
        }

        //Added user access to all courses aswell as favorite functionality
        public ActionResult FavoriteCourse(int id)
        {
            var course = UnitOfWork.Courses.Get(id);

            var userCourse = new UserCourses
            {
                CourseID = course.CourseID,
                User = User.Identity.Name
            };

            UnitOfWork.UserCourses.Add(userCourse);
            UnitOfWork.Complete();
            return View("UserCourses");
        }

        public IActionResult UserCourses()
        {
            // Get the list of course IDs the current user is enrolled in
            var userCourseIds = UnitOfWork.UserCourses
                .GetAll()
                .Where(x => x.User == User.Identity.Name)
                .Select(x => x.CourseID)
                .ToList();

            // Get the actual Course objects based on those IDs
            var courses = UnitOfWork.Courses
                .GetAll()
                .Where(x => userCourseIds.Contains(x.CourseID))
                .ToList();

            return View(courses);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
