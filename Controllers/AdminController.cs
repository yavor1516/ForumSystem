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

        public AdminController(IAdminPanelService adminPanelService, IUserRepository userRepository,ITokenReader tokenReader)
        {
            _userRepository = userRepository;
            _tokenReader = tokenReader;
            _adminPanelService = adminPanelService;
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
                    Users = _userRepository.GetAllUsers()

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
