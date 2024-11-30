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
        public IActionResult Edit(GameGenre genre) { 
            if (ModelState.IsValid)
            {
                if (genre.Id == 0)
                {
                    _context.Genres.Add(genre);
                } else
                {
                    _context.Genres.Update(genre);
                }
                _context.SaveChanges();
                return RedirectToAction("Genres");
            } else
            {
                ViewBag.Action = (genre.Id == 0) ? "Add" : "Edit";
                return View(genre);
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
