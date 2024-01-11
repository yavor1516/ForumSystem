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
            List<Post> posts = (List<Post>)_postRepository.GetAllPosts();// Retrieve the list of posts from your data source
            return View(posts);
        }
    }
}
