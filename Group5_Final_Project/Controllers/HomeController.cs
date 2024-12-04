using Group5_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Group5_Final_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private GamesContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, GamesContext context)
        {
            _logger = logger;
            _context = context;
        }



        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Members()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }


        public IActionResult Games()
        {
            var games = _context.Games.Include(g => g.Genre).Include(g => g.Developer).OrderBy(g => g.Name).ToList();
            return View("~/Views/Game/Games.cshtml", games);
        }

        public IActionResult Genres()
        {
            var genres = _context.Genres.OrderBy(g => g.Genre).ToList();
            return View("~/Views/Genre/Genres.cshtml", genres);
        }

        public IActionResult Platforms()
        {
            var genres = _context.Platforms.OrderBy(g => g.Name).ToList();
            return View("~/Views/Platform/Platforms.cshtml", genres);
        }

        public IActionResult Developers()
        {
            var genres = _context.Developers.OrderBy(g => g.Name).ToList();
            return View("~/Views/Developer/Developers.cshtml", genres);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}