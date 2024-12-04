using Group5_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group5_Final_Project.Controllers
{
    public class GameController : Controller
    {
        private GamesContext _context { get; set; }

        public GameController(GamesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = _context.Genres.OrderBy(g => g.Genre).ToList();
            ViewBag.Platforms = _context.Platforms.OrderBy(p => p.Name).ToList();
            ViewBag.Developers = _context.Developers.OrderBy(d => d.Name).ToList();
            return View("Edit", new Game());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = _context.Genres.OrderBy(g => g.Genre).ToList();
            ViewBag.Platforms = _context.Platforms.OrderBy(p => p.Name).ToList();
            ViewBag.Developers = _context.Developers.OrderBy(d => d.Name).ToList();
            var game = _context.Games.Find(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                if (game.Id == 0)
                {
                    _context.Games.Add(game);
                }
                else
                {
                    _context.Games.Update(game);
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Action = (game.Id == 0) ? "Add" : "Edit";
                ViewBag.Genres = _context.Genres.OrderBy(g => g.Genre).ToList();
                ViewBag.Platforms = _context.Platforms.OrderBy(p => p.Name).ToList();
                ViewBag.Developers = _context.Developers.OrderBy(d => d.Name).ToList();
                return View(game);
            }
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var game = _context.Games.Find(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Delete(Game game)
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}