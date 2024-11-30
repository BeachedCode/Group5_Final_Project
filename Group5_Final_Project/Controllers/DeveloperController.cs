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

    }
}
