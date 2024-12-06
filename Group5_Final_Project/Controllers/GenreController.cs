using Group5_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group5_Final_Project.Controllers
{
    public class GenreController : Controller
    {
        private GamesContext _context { get; set; }

        public GenreController(GamesContext context)
        {
            _context = context;
        }

        [Route ("Genres")]
        public IActionResult Genres()
        {
            var genres = _context.Genres.OrderBy(g => g.Genre).ToList();
            return View(genres);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new GameGenre());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var genre = _context.Genres.Find(id);
            return View(genre);
        }

        [HttpPost]
        public IActionResult Edit(GameGenre genreObject) { 
            if (ModelState.IsValid)
            {
                if (genreObject.Id == 0)
                {
                    _context.Genres.Add(genreObject);
                } else
                {
                    _context.Genres.Update(genreObject);
                }
                _context.SaveChanges();
                return RedirectToAction("Genres");
            } else
            {
                ViewBag.Action = (genreObject.Id == 0) ? "Add" : "Edit";
                return View(genreObject);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var genre = _context.Genres.Find(id);
            return View(genre);
        }

        [HttpPost]
        public IActionResult Delete(GameGenre genre)
        {
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return RedirectToAction("Genres");
        }


    }
}
