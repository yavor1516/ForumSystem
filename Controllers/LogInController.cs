using ForumSystem.Models.DTO;
using ForumSystem.Responses;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ForumSystem.Controllers
{
    public class LogInController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAuthService _authService;

        public LogInController(IAccountService accountService, IAuthService authService)
        {
            _accountService = accountService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new UserLoginDto();
           
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult LogIn(UserLoginDto loginRequest)
        {
           
            Console.WriteLine(  );
            var loginModel = new UserLoginDto
            {
                Username = loginRequest.Username,
                Password = loginRequest.Password
            };

            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }

            try
            {
                var user = _accountService.LoginUser(loginRequest);
                AuthenticatedUserResponse token = new AuthenticatedUserResponse()
                {
                    accessToken = _accountService.GenerateToken(user)
                };
              //  HttpContext.Response.Headers.Add("Authorization", "Bearer " + token.accessToken);
                HttpContext.Response.Cookies.Append("access_token", token.accessToken, new CookieOptions { HttpOnly = true });
                var tokenTest = new JwtSecurityTokenHandler().ReadJwtToken(token.accessToken);
                //var identity = (ClaimsIdentity)User.Identity;
                //identity.AddClaims(tokenTest.Claims);
                var identity = new ClaimsPrincipal(new ClaimsIdentity(tokenTest.Claims));
                //HttpContext.User.AddIdentity(identity);

                // Store the access token in an HttpOnly cookie
                //  var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                return RedirectToAction("Index", "Home");
                
            }
            catch (Exception e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }
        }

    }
}
