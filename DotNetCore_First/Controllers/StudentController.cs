using Microsoft.AspNetCore.Mvc;
using DotNetCore_First.Models;
using DotNetCore_First.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Collections.Generic;
using System.Linq;
using NuGet.Protocol.Core.Types;

namespace DotNetCore_First.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbCon _db;
        public StudentController(ApplicationDbCon db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objStudents = _db.Students.ToList();
            return View(objStudents);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            _db.Students.Add(obj);
            _db.SaveChanges();
            TempData["KeyMessage"] = "Record created successfully !!";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var StudentFromDb = _db.Students.Find(id);
            if (StudentFromDb == null)
            {
                return NotFound();
            }
            return View(StudentFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
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
            var StudentFromDb = _db.Students.Find(id);
            if (StudentFromDb == null)
            {
                return NotFound();
            }
            return View(StudentFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Student obj)
        {
            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
