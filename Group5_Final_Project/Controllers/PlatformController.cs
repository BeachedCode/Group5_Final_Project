using Group5_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group5_Final_Project.Controllers{

    public class PlatformController : Controller {

        private GamesContext _context { get; set; }

        public PlatformController(GamesContext context) {
            _context = context;
        }

        [Route ("Platforms")]
        public IActionResult Platforms()
        {
            var platforms = _context.Platforms.OrderBy(p => p.Name).ToList();
            return View(platforms);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Platform());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var platform = _context.Platforms.Find(id);
            return View(platform);
        }

        [HttpPost]
        public IActionResult Edit(Platform platform)
        {
            if (ModelState.IsValid)
            {
                if (platform.Id == 0)
                {
                    _context.Platforms.Add(platform);
                } else
                {
                    _context.Platforms.Update(platform);
                }
                _context.SaveChanges();
                return RedirectToAction("Platforms");
            } else
            {
                ViewBag.Action = (platform.Id == 0) ? "Add" : "Edit";
                return View(platform);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var platform = _context.Platforms.Find(id);
            return View(platform);
        }

        [HttpPost]
        public IActionResult Delete(Platform platform)
        {
            _context.Platforms.Remove(platform);
            _context.SaveChanges();
            return RedirectToAction("Platforms");
        }


    }


}