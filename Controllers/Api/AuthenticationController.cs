using ForumSystem.Exceptions;
using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Models.DTO;
using ForumSystem.Responses;
using ForumSystem.Services;
using ForumSystem.Services.TokenGenerator;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Text;

namespace ForumSystem.Controllers.Api
{
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthenticationController(IAccountService accountService)
        {
            _accountService = accountService;

        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto registerRequest)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }
            try
            {
                _accountService.RegisterUser(registerRequest);

                return Ok();
            }
            catch (DuplicateEntityException e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto loginRequest)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }
            try
            {
                var user = _accountService.LoginUser(loginRequest);

                return Ok(new AuthenticatedUserResponse()
                {
                    accessToken = _accountService.GenerateToken(user)
                }); ;
            }
            catch (Exception e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }

        }
    }
}
