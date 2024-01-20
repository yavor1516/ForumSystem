using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
