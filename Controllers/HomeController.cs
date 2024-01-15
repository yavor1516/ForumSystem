using ForumSystem.Models;
using ForumSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepository;
        public HomeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IActionResult Index()
        {
            var posts = _postRepository.GetAllPosts();// Retrieve the list of posts from your data source
            return View(posts);
        }
        public IActionResult Home()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}
