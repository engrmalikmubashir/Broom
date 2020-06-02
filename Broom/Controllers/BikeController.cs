using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Broom.AppDbContext;
using Broom.Models;
using Broom.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace Broom.Controllers
{
    public class BikeController : Controller
    {
        private readonly BroomDbContext _context;

      //  private readonly HostingEnvironment _hosting;

        [BindProperty]
        public BikeViewModel BikeVM { get; set; }

        public BikeController(BroomDbContext context)
        {
            _context = context;
          //  _hosting = hosting; , HostingEnvironment hosting
            BikeVM = new BikeViewModel()
            {
                Makes = _context.Makes.ToList(),
                BModels = _context.BModels.ToList(),
                Bike = new Models.Bike()
            };
        }

        public IActionResult Index()
        {
            var bikes = _context.Bikes
                .Include(m => m.Make)
                .Include(m => m.BModel);
            return View(bikes.ToList());
        }

        public IActionResult Create()
        {
            return View(BikeVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(BikeVM);
            }

            _context.Bikes.Add(BikeVM.Bike);
            _context.SaveChanges();

            //////////////////////////
            // save bike logic
            //////////////////////////

         //   var BikeID = BikeVM.Bike.Id;

         //   string wwwrootPath = _hosting.ContentRootPath;

        //    var files = HttpContext.Request.Form.Files;

    //        var SavedBike = _context.Bikes.Find(BikeID);

     /*       if (files.Count != 0)
            {
                var ImagePath = @"images/bike/";
                var Extension = Path.GetExtension(files[0].FileName);
                var RelativeImagePath = ImagePath + BikeID + Extension;
                var AbsolutePath = Path.Combine(wwwrootPath, RelativeImagePath);

                using (var fileStream = new FileStream(AbsolutePath, FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                SavedBike.ImagePath = RelativeImagePath;
                _context.SaveChanges();
            }
     */
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            BikeVM.Bike = _context.Bikes.Include(m => m.Make)
                .SingleOrDefault(m => m.Id == id);
            if (BikeVM.Bike == null)
            {
                return NotFound();
            }

            return View(BikeVM);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(BikeVM);
            }
            _context.Update(BikeVM.Bike);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Bike Bike = _context.Bikes.Find(id);
            if (Bike == null)
            {
                return NotFound();
            }
            _context.Bikes.Remove(Bike);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
