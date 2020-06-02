using System.Linq;
using Broom.AppDbContext;
using Broom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Broom.Controllers
{
    [Authorize(Roles = "Admin,Executive")]
    public class MakeController : Controller
    {
        private readonly BroomDbContext _context;

        public MakeController(BroomDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Makes.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Make make)
        {
            if (ModelState.IsValid)
            {
                _context.Makes.Add(make);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var make = _context.Makes.Find(id);
            if (make == null)
            {
                return NotFound();
            }

            _context.Makes.Remove(make);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var make = _context.Makes.Find(id);
            if (make == null)
            {
                return NotFound();
            }
            return View(make);
        }

        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                _context.Makes.Update(make);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }

    }
}
