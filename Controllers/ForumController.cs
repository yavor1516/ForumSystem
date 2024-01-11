using ForumSystem.Exceptions;
using ForumSystem.Models;
using ForumSystem.Repositories;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ForumSystem.Controllers
{
    public class ForumController : Controller
    {
        private readonly IPostRepository _postRepository;
        public ForumController(IPostRepository postRepository)
        {
            _postRepository=postRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
           var posts = _postRepository.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult Create() 
        {
            var post = new PostViewModel();
            return View(post);
        }

      /*  [HttpPost]
        public IActionResult Create(PostViewModel postViewModel) 
        { 

        }*/   //TODO
    }
}
