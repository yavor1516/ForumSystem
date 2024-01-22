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
        private readonly IEditPostService _editPostService;
        public HomeController(IEditPostService editPostService,IPostRepository postRepository,IForumDataService forumDataService , IAccountService accountService , ITokenReader tokenReader)
        {
            _postRepository = postRepository;
            _forumDataService = forumDataService;
            _accountService = accountService;
            _tokenReader = tokenReader;
            _editPostService = editPostService;
        }


        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            _postRepository.CreatePost(post);
            return RedirectToAction("Index","Home");
        }

		[HttpPost]
		public IActionResult EditPost(int id, EditPostDTO editPostDTO)
		{
			try
			{
				var editedPost = _editPostService.EditPost(editPostDTO, id);
				return RedirectToAction("Index", "Home");
			}
			catch (Exception ex)
			{
				// Handle the exception, e.g., log it and show an error message.
				ModelState.AddModelError(string.Empty, "Error editing post: " + ex.Message);
				return View(); // Return to a view where the user can try again.
			}
		}

		[HttpPost]
		public IActionResult DeletePost(int id)
		{
			try
			{
				bool result = _editPostService.DeletePost(id);
				if (result)
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					// Handle the case where post deletion was not successful.
					ModelState.AddModelError(string.Empty, "Error deleting post.");
					return View(); // Return to a view or show an error message.
				}
			}
			catch (Exception ex)
			{
				// Handle the exception, e.g., log it and show an error message.
				ModelState.AddModelError(string.Empty, "Error deleting post: " + ex.Message);
				return View(); // Return to a view where the user can try again.
			}
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
