using ForumSystem.Models;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    public class PostController : Controller
    {
        private readonly IForumDataService _forumDataService;
        public PostController(IForumDataService forumDataService)
        {
            _forumDataService=forumDataService;
        }

        public IActionResult Index(int id)
        {
            var ViewModel = new PostViewModel()
            {
                Post = _forumDataService.GetPostByPostId(id)

            };
            return View(ViewModel);
        }

    }
}
