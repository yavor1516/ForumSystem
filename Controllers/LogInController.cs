using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    public class LogInController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
