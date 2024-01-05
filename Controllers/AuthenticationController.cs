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

namespace ForumSystem.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly AccessTokenGenerator _tokenGenerator;
        public AuthenticationController(IAccountService accountService, IPasswordHasher passwordHasher, AccessTokenGenerator tokenGenerator)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto registerRequest)
        {
            // authService.Reigster(registerRequest.Username, registerRequest.Password);
            //authService.Reigster(UserDto);
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }
           User existingUserByEmail = _accountService.GetByEmail(registerRequest.Email);
            if(existingUserByEmail != null)
            {
                return Conflict(new ErrorResponse("Email already exist!"));
            }

            User existingUserByUsername = _accountService.GetByUsername(registerRequest.Username);
            if(existingUserByUsername != null)
            {
                return Conflict(new ErrorResponse("Username already exist!"));
            }

            string passwordHash = _passwordHasher.HashPassword(registerRequest.Password);
            User registerUser = new User()
            {
                Email = registerRequest.Email,
                Username = registerRequest.Username,
                PasswordHash = Encoding.UTF8.GetBytes(passwordHash),
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
            };
            _accountService.CreateUser(registerUser);

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto loginRequest)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }
            User user = _accountService.GetByUsername(loginRequest.Username);
            if (user == null)
            {
                return Unauthorized();
            }
            bool isCorrectPassword = _passwordHasher.VerifyPassword(loginRequest.Password, Encoding.UTF8.GetString(user.PasswordHash));
            if(!isCorrectPassword)
            {
                return Unauthorized();
            }
            string accessToken = _tokenGenerator.GenerateToken(user);
            return Ok(new AuthenticatedUserResponse()
            {
                accessToken = accessToken
            });
        }
    }
}
