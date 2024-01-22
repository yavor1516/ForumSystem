using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Models.DTO;
using ForumSystem.Repositories;
using ForumSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ForumSystem.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IForumDataService _forumDataService;
        private readonly IAccountService _accountService;
        private readonly ITokenReader _tokenReader;
        public HomeController(IPostRepository postRepository,IForumDataService forumDataService , IAccountService accountService , ITokenReader tokenReader)
        {
            _postRepository = postRepository;
            _forumDataService = forumDataService;
            _accountService = accountService;
            _tokenReader = tokenReader;
        }


        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            _postRepository.CreatePost(post);
            // Handle the form submission here
            // You can use postTitle, postContent, and postVisibility to create a new post

            // Redirect to a different action/view after handling the form data
            return RedirectToAction("Index","Home");
        }

        public IActionResult Index()
        {
            var cookie = HttpContext.Request.Cookies;
            var tokenAsText = cookie["access_token"];
         
            if(tokenAsText == null)
            {
                var viewModel = new HomeVeiwModel
                {
                    Posts = _forumDataService.ShowAllPosts(),
                    registredUsers = _forumDataService.GetTotalUsersCount(),
                    onlineUsers = _forumDataService.GetOnlineUsers(),
                    notAuthenticated = false
                };
                return View(viewModel);
            }

            var user = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Name)?.Value;
            
            if(user != null)
            {
                var viewModel = new HomeVeiwModel
                {
                    Posts = _forumDataService.ShowAllPosts(),
                    registredUsers = _forumDataService.GetTotalUsersCount(),
                    onlineUsers = _forumDataService.GetOnlineUsers(),
                     notAuthenticated = true

                };
                return View(viewModel);
            }
            else
            {
                return View(null);
            }
            //var posts = _postRepository.GetAllPosts();// Retrieve the list of posts from your data source
            //return View(posts);
        }
        public IActionResult Home()
        {
            var viewModel = new HomeVeiwModel
            {
                Posts = _forumDataService.ShowAllPosts(),
                registredUsers = _forumDataService.GetTotalUsersCount(),
                onlineUsers = _forumDataService.GetOnlineUsers()


            };
            return View(viewModel);
            //ViewBag.Title = "Home";
            //ViewBag.TotalUsers = "33";
            //ViewBag.UsersOnline = "3";

            //return View();
        }
    }
}
