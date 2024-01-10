using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
