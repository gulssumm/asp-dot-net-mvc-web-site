using DotNetCore_First.Data;
using Microsoft.AspNetCore.Mvc;
using DotNetCore_First.Models;

namespace DotNetCore_First.Controllers
{
    public class RectorController : Controller
    {
        private readonly ApplicationDbCon _db;
        public RectorController(ApplicationDbCon db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Rector> objRectorsList = _db.Rectors.ToList();
            return View(objRectorsList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rector obj)
        {
            _db.Rectors.Add(obj);
            _db.SaveChanges();
            TempData["KeyMessage"] = "Record created successfully !!";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string? name)
        {
            if (name == null)
            {
                return NotFound();
            }
            var RectorFromDb = _db.Rectors.Find(name);
            if (RectorFromDb == null)
            {
                return NotFound();
            }
            return View(RectorFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Rector obj)
        {
            if (ModelState.IsValid)
            {
                _db.Rectors.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(string? name)
        {
            if (name == null)
            {
                return NotFound();
            }
            var RectorFromDb = _db.Rectors.Find(name);
            if (RectorFromDb == null)
            {
                return NotFound();
            }
            return View(RectorFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Rector obj)
        {
            _db.Rectors.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
