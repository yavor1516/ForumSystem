using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
