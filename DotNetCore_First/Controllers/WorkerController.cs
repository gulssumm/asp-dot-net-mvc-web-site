using Microsoft.AspNetCore.Mvc;
using DotNetCore_First.Models;
using DotNetCore_First.Data;

namespace DotNetCore_First.Controllers
{
    public class WorkerController : Controller
    {
        private readonly ApplicationDbCon _db;
        public WorkerController(ApplicationDbCon db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Worker> objWorkersList = _db.Workers.ToList();
            return View(objWorkersList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Worker obj)
        {
            _db.Workers.Add(obj);
            _db.SaveChanges();
            TempData["KeyMessage"] = "Record created successfully !!";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var WorkersFromDb = _db.Workers.Find(id);
            if (WorkersFromDb == null)
            {
                return NotFound();
            }
            return View(WorkersFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Worker obj)
        {
            if (ModelState.IsValid)
            {
                _db.Workers.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var WorkersFromDb = _db.Workers.Find(id);
            if (WorkersFromDb == null)
            {
                return NotFound();
            }
            return View(WorkersFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Worker obj)
        {
            _db.Workers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

