using ForumSystem.Services;
using ForumSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ForumSystem.Exceptions;
using ForumSystem.Responses;
using System.Security.Claims;
using ForumSystem.Models.DTO;

namespace ForumSystem.Controllers
{
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
                var comment = new Comment
                {
                    PostID = commentDto.PostID,
                    UserID = commentDto.UserID,
                    Content = commentDto.Content,
                };

                _commentService.CreateComment(commentDto);
                return Ok();

            }
            catch (DuplicateEntityException e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }
        }
    }
}

