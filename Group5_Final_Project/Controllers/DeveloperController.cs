using Microsoft.AspNetCore.Mvc;

namespace Group5_Final_Project.Controllers
{
    public class DeveloperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
