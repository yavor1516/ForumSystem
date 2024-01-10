using ForumSystem.Exceptions;
using ForumSystem.Models;
using ForumSystem.Repositories;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    public class ForumController : Controller
    {
        private readonly IPostRepository _postRepository;
        public ForumController(IPostRepository postRepository)
        {
            _postRepository=postRepository;
        }
        public IActionResult Index()
        {
            List<Post> posts = (List<Post>)_postRepository.GetAllPosts();
            return View(posts);
        }
        public IActionResult Details(int id)
        {
            try
            {
                Post post = _postRepository.GetPostByPostId(id);
                return View(post);
            }
            catch (EntityNotFountException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["Error"]=ex.Message;
                return View("Error");
            }
        }
    }
}
