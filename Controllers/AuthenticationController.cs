using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Models.DTO;
using ForumSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ForumSystem.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthenticationController(IAccountService accountService,IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto registerRequest)
        {
           if(!ModelState.IsValid)
            {
                return BadRequest();
            }
           User existingUserByEmail = _accountService.GetByEmail(registerRequest.Email);
            if(existingUserByEmail != null)
            {
                return Conflict();
            }

            User existingUserByUsername = _accountService.GetByUsername(registerRequest.Username);
            if(existingUserByUsername != null)
            {
                return Conflict();
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
    }
}
