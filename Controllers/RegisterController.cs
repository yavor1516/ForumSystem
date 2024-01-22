using ForumSystem.Exceptions;
using ForumSystem.Models;
using ForumSystem.Models.DTO;
using ForumSystem.Responses;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IForumDataService _forumDataService;
        private readonly IAccountService _accountService;

        public RegisterController(IForumDataService forumDataService, IAccountService accountService)
        {
            _forumDataService = forumDataService;
            _accountService = accountService;
        }

       
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new UserDto();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(UserDto user)
        {
            var registerModel = new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                UserId = _forumDataService.GetTotalUsersCount()+1
            };
         

            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }
            try
            {
                _accountService.RegisterUser(registerModel);

                return RedirectToAction("Index", "Login");
            }
            catch (DuplicateEntityException e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }
        }


    }
}
