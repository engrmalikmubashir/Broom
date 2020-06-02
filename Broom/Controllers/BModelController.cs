using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Broom.AppDbContext;
using Broom.Helpers;
using Broom.Models;
using Broom.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Broom.Controllers
{
    [Authorize(Roles = "Admin,Executive")]
    public class BModelController : Controller
    {
        private readonly BroomDbContext _context;

        [BindProperty]
        public BModelViewModel BModelVM { get; set; }

        public BModelController(BroomDbContext context)
        {
            _context = context;
            BModelVM = new BModelViewModel()
            {
                Makes = _context.Makes.ToList(),
                BModel = new Models.BModel()
            };
        }

        public IActionResult Index()
        {
            var model = _context.BModels.Include(m => m.Make);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(BModelVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(BModelVM);
            }

            _context.BModels.Add(BModelVM.BModel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            BModelVM.BModel = _context.BModels.Include(m => m.Make)
                .SingleOrDefault(m => m.Id == id);
            if (BModelVM.BModel == null)
            {
                return NotFound();
            }

            return View(BModelVM);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(BModelVM);
            }
            _context.Update(BModelVM.BModel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            BModel bModel = _context.BModels.Find(id);
            if (bModel == null)
            {
                return NotFound();
            }
            _context.BModels.Remove(bModel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
