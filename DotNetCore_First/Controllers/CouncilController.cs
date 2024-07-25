using Microsoft.AspNetCore.Mvc;
using DotNetCore_First.Models;
using DotNetCore_First.Data;

namespace DotNetCore_First.Controllers
{
    public class CouncilController : Controller
    {
        private readonly ApplicationDbCon _db;
        public CouncilController(ApplicationDbCon db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Council> objCouncilList = _db.Councils.ToList();
            return View(objCouncilList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Council obj)
        {
            _db.Councils.Add(obj);
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
            var CouncilFromDb = _db.Councils.Find(id);
            if (CouncilFromDb == null)
            {
                return NotFound();
            }
            return View(CouncilFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Council obj)
        {
            if (ModelState.IsValid)
            {
                _db.Councils.Update(obj);
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
            var CouncilFromDb = _db.Councils.Find(id);
            if (CouncilFromDb == null)
            {
                return NotFound();
            }
            return View(CouncilFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Council obj)
        {
            _db.Councils.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

