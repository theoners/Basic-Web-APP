using TeisterMask.Models;

namespace TeisterMask.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using TeisterMask.Data;

    public class TaskController : Controller
    {
        private readonly TeisterMaskDbContext teisterMaskDbContext;

        public TaskController(TeisterMaskDbContext teisterMaskDbContext)
        {
            this.teisterMaskDbContext = teisterMaskDbContext;
        }
        public IActionResult Index()
        {
            var data = teisterMaskDbContext.Tasks.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Title is required!";
                return this.View(task);
            }
            else
            {
                teisterMaskDbContext.Tasks.Add(task);
                teisterMaskDbContext.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var taskForEdit = teisterMaskDbContext.Tasks.FirstOrDefault(x => x.Id == id);
            if (taskForEdit == null)
            {
                return RedirectToAction("Index");
            }

            return this.View(taskForEdit);
        }

        [HttpPost]
        public IActionResult Edit(Task editTask)
        {

            var Oldtask = teisterMaskDbContext.Tasks.FirstOrDefault(x => x.Id == editTask.Id);
            if (Oldtask == null)
            {
                return RedirectToAction("Index");
            }

            Oldtask.Title = editTask.Title;
            Oldtask.Status = editTask.Status;
            if (!ModelState.IsValid)
            {
                    TempData["ErrorMessage"] = "Title is required!";
                    return this.View(Oldtask);
            }
            else
            {
                teisterMaskDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var taskForDelete = teisterMaskDbContext.Tasks.FirstOrDefault(x => x.Id == id);
            if (taskForDelete == null)
            {
                return RedirectToAction("Index");
            }

            return this.View(taskForDelete);
        }
        [HttpPost]
        public IActionResult Delete(Task task)
        {
            teisterMaskDbContext.Tasks.Remove(task);
            teisterMaskDbContext.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}