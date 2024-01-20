using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Repositories;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminPanelService _adminPanelService;
        private readonly IUserRepository _userRepository;

        public AdminController(IAdminPanelService adminPanelService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _adminPanelService = adminPanelService;
        }

       
        public IActionResult Index()
        {
            var viewModel = new AdminViewModel
            {
                Users = _userRepository.GetAllUsers()

            };
            return View(viewModel);
            
        }
    }
}
