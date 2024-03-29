﻿using ForumSystem.Exceptions;
using ForumSystem.Models;
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
    [Route("/panel")]
    public class CreatePostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IEditPostService _editPostService;
        public CreatePostController(IPostService postService, IEditPostService editPostService)
        {
            _postService = postService;
            _editPostService = editPostService;
        }
        [Authorize]
        [HttpPost("Create")]
        public IActionResult CreatePost([FromBody] PostDto postDTO)
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
                if(userisBlocked != "True")
                {
                    _postService.CreatePost(postDTO, user);

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
