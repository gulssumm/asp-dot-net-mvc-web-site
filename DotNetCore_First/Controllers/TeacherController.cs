using Microsoft.AspNetCore.Mvc;
using DotNetCore_First.Models;
using DotNetCore_First.Data;

namespace DotNetCore_First.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbCon _db;
        public TeacherController(ApplicationDbCon db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Teacher> objTeachersList = _db.Teachers.ToList();
            return View(objTeachersList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher obj)
        {
            _db.Teachers.Add(obj);
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
            var TeacherFromDb = _db.Teachers.Find(id);
            if (TeacherFromDb == null)
            {
                return NotFound();
            }
            return View(TeacherFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Update(obj);
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
            var TeacherFromDb = _db.Teachers.Find(id);
            if (TeacherFromDb == null)
            {
                return NotFound();
            }
            return View(TeacherFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Teacher obj)
        {
            _db.Teachers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

