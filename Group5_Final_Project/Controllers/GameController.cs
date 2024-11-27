using Group5_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Group5_Final_Project.Controllers
{
    public class GameController : Controller
    {
        private readonly GamesContext _context;

        public GameController(GamesContext context)
        {
            _context = context;
        }

        // GET: Game/Index
        public IActionResult Index()
        {
            var games = _context.Games
                                 .Include(g => g.Genre)
                                 .Include(g => g.Developer)
                                 .ToList();

            // Log information for debugging
            if (games == null || !games.Any())
            {
                Console.WriteLine("No games found or the list is null.");
            }
            else
            {
                foreach (var game in games)
                {
                    if (game.Genre == null)
                        Console.WriteLine($"Game ID {game.Id} has a null Genre");
                    if (game.Developer == null)
                        Console.WriteLine($"Game ID {game.Id} has a null Developer");
                }
            }

            return View(games);
        }

        // GET: Game/Add
        public IActionResult Add()
        {
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Developers = _context.Developers.ToList();
            return View();
        }

        // POST: Game/Add
        [HttpPost]
        public IActionResult Add(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Developers = _context.Developers.ToList();
            return View(game);
        }

        // GET: Game/Edit/{id}
        public IActionResult Edit(int id)
        {
            var game = _context.Games
                                .Include(g => g.Genre)
                                .Include(g => g.Developer)
                                .FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Developers = _context.Developers.ToList();
            return View(game);
        }

        // POST: Game/Edit/{id}
        [HttpPost]
        public IActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Developers = _context.Developers.ToList();
            return View(game);
        }

        // GET: Game/Delete/{id}
        public IActionResult Delete(int id)
        {
            var game = _context.Games
                                .Include(g => g.Genre)
                                .Include(g => g.Developer)
                                .FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Game/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var game = _context.Games.Find(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}