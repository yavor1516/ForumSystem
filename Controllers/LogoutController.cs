using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ForumSystem.Controllers
{
    public class LogoutController : Controller
    {
        private readonly ITokenReader _tokenReader;
        private readonly IUserDataService _userDataService;
        private readonly IForumDataService _forumDataService;
        public LogoutController(ITokenReader tokenReader, IUserDataService userDataService, IForumDataService forumDataService)
        {
            _tokenReader = tokenReader;
            _userDataService = userDataService;
            _forumDataService = forumDataService;

        }

        public IActionResult Index()
        {
            var cookie = HttpContext.Request.Cookies;
            var tokenAsText = cookie["access_token"];
            var user = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Name)?.Value;
            User userToUpdate = _userDataService.GetByUsername(user);
            userToUpdate.isOnline = false;
            _forumDataService.UpdateUserStatus(userToUpdate);
            HttpContext.Response.Cookies.Delete("access_token");
            return RedirectToAction("Index", "Home");
        }
    }
}
