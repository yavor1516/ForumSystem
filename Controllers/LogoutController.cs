using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Response.Cookies.Delete("access_token");
            return RedirectToAction("Index", "Home");
        }
    }
}
