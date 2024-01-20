using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Repositories;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Linq; // Import System.Linq for ToList()
using System.Security.Claims;

public class ProfileController : Controller
{
    private readonly IUserDataService _userDataService;
    private readonly IForumDataService _forumDataService;
    private readonly ITokenReader _tokenReader;

    public ProfileController(IUserDataService userDataService, IForumDataService forumDataService, ITokenReader tokenReader)
    {
        _userDataService = userDataService;
        _forumDataService = forumDataService;
        _tokenReader = tokenReader;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var cookie = HttpContext.Request.Cookies;
        var tokenAsText = cookie["access_token"];
        ViewBag.Title = "Home";
        if (tokenAsText == null)
        {
            var model = new ProfileViewModel
            {

                notAuthenticated = false
            };
            return RedirectToAction("Index", "Home");
        }

        var user = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Name)?.Value;
        if (user != null)
        {
            var viewModel = new ProfileViewModel
            {
                User = _userDataService.GetByUsername(user),
                TotalUsers = _forumDataService.GetTotalUsersCount(),
                Posts = _forumDataService.GetAllPostsByUsername(user),// Convert to a list if necessary
                notAuthenticated = true

            };

            return View(viewModel);
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
        // Fetch the user and their posts from the database



    }

   
}