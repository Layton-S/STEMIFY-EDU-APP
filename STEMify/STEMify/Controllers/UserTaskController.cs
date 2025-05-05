using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using STEMify.Data.Interfaces;
using STEMify.Models.User;

namespace STEMify.Controllers
{
    [Authorize]
    public class UserTaskController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public UserTaskController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var tasks = UnitOfWork.UserTasks.Get(x => x.UserId == userId); // Fetch tasks for the current user
            return View(tasks); // Pass tasks to the view
        }


        // GET: Loads the create task form as a partial view
        public IActionResult Create()
        {
            var newTask = new UserTask();
            return PartialView("_CreateTaskPartial", newTask);
        }

        // POST: Handles form submission for creating a task
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creates(UserTask task)
        {
            task.UserId = _userManager.GetUserId(User);
            ModelState.Remove("UserId");
            if(!ModelState.IsValid)
            {
                // Return the form again with validation messages if invalid
                return PartialView("_CreateTaskPartial", task);
            }

            // Associate the task with the current user

            // Save the task using Unit of Work pattern
            UnitOfWork.UserTasks.Add(task);
            UnitOfWork.Complete();

            // Return success status for AJAX handler
            return Json(new { success = true });
        }


        public IActionResult Edit(int id)
        {
            var task = UnitOfWork.UserTasks.Get(id);
            if(task == null || task.UserId != _userManager.GetUserId(User))
                return NotFound();

            return PartialView("_EditTaskPartial", task);
        }

        [HttpPost]
        public IActionResult Edit(UserTask task)
        {
            if(ModelState.IsValid)
            {
                UnitOfWork.UserTasks.Update(task);
                UnitOfWork.Complete();
                return Json(new { success = true });
            }
            return PartialView("_EditTaskPartial", task);
        }

        public IActionResult Delete(int id)
        {
            var task = UnitOfWork.UserTasks.Get(id);
            if(task == null || task.UserId != _userManager.GetUserId(User))
                return NotFound();

            return PartialView("_DeleteTaskPartial", task);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = UnitOfWork.UserTasks.Get(id);
            if(task == null)
                return NotFound();

            UnitOfWork.UserTasks.Remove(task);
            UnitOfWork.Complete();
            return Json(new { success = true });
        }

        public IActionResult Upcoming()
        {
            var userId = _userManager.GetUserId(User);
            var upcomingTasks = UnitOfWork.UserTasks.Get(x => x.UserId == userId);
            return PartialView("_UpcomingTasksPartial", upcomingTasks);
        }
    }
}
