using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Repositories;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ForumSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminPanelService _adminPanelService;
        private readonly IUserRepository _userRepository;
        private readonly ITokenReader _tokenReader;
        private readonly IForumDataService _forumDataService;

        public AdminController(IAdminPanelService adminPanelService, IUserRepository userRepository,ITokenReader tokenReader, IForumDataService forumDataService)
        {
            _userRepository = userRepository;
            _tokenReader = tokenReader;
            _adminPanelService = adminPanelService;
            _forumDataService = forumDataService;
        }

        [HttpPost]
        public IActionResult BlockUser(AdminViewModel model)
        {
            var cookie = HttpContext.Request.Cookies;
            var tokenAsText = cookie["access_token"];

          
                try
            {
                if (tokenAsText != null)
                {
                    var user = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Name)?.Value;
                  
                    var userRole = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Role)?.Value;

                    if (user != null && userRole == "True")
                    {
                        var userToBlock = _adminPanelService.BlockUser(model.username);

                        return RedirectToAction($"");

                    }
                }
                return Unauthorized();


            }
            catch (Exception e)
            {
                return Conflict(new Exception("user doenst exist!!"));
            }
        }

        [HttpPost]
        public IActionResult UnBlockUser(AdminViewModel model)
        {
            var cookie = HttpContext.Request.Cookies;
            var tokenAsText = cookie["access_token"];


            try
            {
                if (tokenAsText != null)
                {
                    var user = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Name)?.Value;

                    var userRole = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Role)?.Value;

                    if (user != null && userRole == "True")
                    {
                        var userToBlock = _adminPanelService.UnBlockUser(model.username);

                        return RedirectToAction($"");

                    }
                }
                return Unauthorized();


            }
            catch (Exception e)
            {
                return Conflict(new Exception("user doenst exist!!"));
            }
        }
        public IActionResult Index()
        {
            try
            {
                var cookie = HttpContext.Request.Cookies;
                var tokenAsText = cookie["access_token"];
                var user = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Name)?.Value;
                var userRole = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Role)!.Value;
                var viewModel = new AdminViewModel
                {
                    Users = _userRepository.GetAllUsers(),
                    user = _userRepository.GetUserByUsername(user),
                    registredUsers = _forumDataService.GetTotalUsersCount(),
                    onlineUsers = _forumDataService.GetOnlineUsers()

                };
             
                if (user != null && userRole == "True")
                {
                    // var userToBlock = _adminPanelService.BlockUser(username);

                    return View(viewModel);

                }

                return RedirectToAction("Index", "Home");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
