using ForumSystem.Models.DTO;
using ForumSystem.Responses;
using ForumSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ForumSystem.Controllers.Api
{
    [ApiController]
    [Authorize]
    [Route("/adminPanel")]
    public class AdminPanelController : ControllerBase
    {
        private readonly IAdminPanelService _adminPanelService;

        public AdminPanelController(IAdminPanelService adminPanelService)
        {
            _adminPanelService = adminPanelService;
        }
       
        [Authorize]
    
        [HttpPut("block/{username}")]
        public IActionResult BlockUser(string username)
        {

            try
            {
                var user = User.FindFirst(ClaimTypes.Name)?.Value;
                var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

                if (user != null && userRole == "True")
                {
                    var userToBlock = _adminPanelService.BlockUser(username);

                    return Ok();

                }
                return Unauthorized();


            }
            catch (Exception e)
            {
                return Conflict(new Exception("user doenst exist!!"));
            }
        }
        [HttpPut("unblock/{username}")]
        public IActionResult UnBlockUser(string username)
        {

            try
            {
                var user = User.FindFirst(ClaimTypes.Name)?.Value;
                var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

                if (user != null && userRole == "True")
                {
                    var userToBlock = _adminPanelService.UnBlockUser(username);

                    return Ok();

                }
                return Unauthorized();


            }
            catch (Exception e)
            {
                return Conflict(new Exception("user doenst exist!!"));
            }
        }

    }
}
