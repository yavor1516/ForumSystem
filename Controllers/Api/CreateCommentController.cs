using ForumSystem.Services;
using ForumSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ForumSystem.Exceptions;
using ForumSystem.Responses;
using System.Security.Claims;
using ForumSystem.Models.DTO;

namespace ForumSystem.Controllers.Api
{
    ///Forum/Details/1 <summary>
    /// Forum/Details/1
    /// </summary>
    [Route("/Forum/Details")]
    [ApiController]
    [Authorize]
    public class CreateCommentController : ControllerBase
    {
        private readonly ICreateCommentService _commentService;

        public CreateCommentController(ICreateCommentService commentService)
        {
            _commentService = commentService;
        }

        [Authorize]
        [HttpPost("CreateComment")]
        public IActionResult CreateComment([FromBody] CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }

            try
            {
                var user = User.FindFirst(ClaimTypes.Name)?.Value;
                var userisBlocked = User.FindFirst(ClaimTypes.UserData)?.Value;
                if (userisBlocked != "True")
                {
                    _commentService.CreateComment(commentDto, user);
                    return Ok();
                }
                return Unauthorized("Your are blocked by admin!!!");
             

            }
            catch (DuplicateEntityException e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }
        }
    }
}

