using Group5_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group5_Final_Project.Controllers
{
    public class DeveloperController : Controller
    {
        private GamesContext _context { get; set; }

        public DeveloperController(GamesContext context)
        {
            _context = context;
        }

        [Route("Developers")]
        public IActionResult Developers()
        {
            var developers = _context.Developers.OrderBy(d => d.Name).ToList();
            return View(developers);
        }

        [HttpGet]
        public IActionResult Add(){
            ViewBag.Action = "Add";
            return View("Edit", new Developer());
        }

        [HttpGet]
        public IActionResult Edit(int Id){
            ViewBag.Action = "Edit";
            var developer = _context.Developers.Find(Id);
            return View(developer);
        }

        [HttpPost]
        public IActionResult Edit(Developer developer){
            if (ModelState.IsValid){
                if (developer.Id == 0){
                    _context.Developers.Add(developer);
                }else{
                    _context.Developers.Update(developer);
                }
                _context.SaveChanges();
                return RedirectToAction("Developers");
            }else{
                ViewBag.Action = (developer.Id ==0) ? "Add" : "Edit";
                return View(developer);
                 }
        }

        [HttpGet]
        public IActionResult Delete(int id){
            var developer = _context.Developers.Find(id);
            return View(developer);
        }

        [HttpPost]
        public IActionResult Delete(Developer developer){
            _context.Developers.Remove(developer);
            _context.SaveChanges();
            return RedirectToAction("Developers");
        }
    }
}
