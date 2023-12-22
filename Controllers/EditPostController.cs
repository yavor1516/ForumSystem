using ForumSystem.Exceptions;
using ForumSystem.Helpers;
using ForumSystem.Models.DTO;
using ForumSystem.Models;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    [ApiController]
    [Route("/feed/edit")]
    public class EditPostController:ControllerBase
    {
        private readonly IEditPostService _editPostService;
        private readonly IModelMapper _modelMapper;
        public EditPostController(IEditPostService editPostService, IModelMapper modelMapper)
        {
            _editPostService = editPostService;
            _modelMapper = modelMapper;
        }
        [HttpGet("{id}")]
        public IActionResult DeletePostById(int id)
        {
            try
            {
                _editPostService.DeletePost(id);
                return Ok(new { message = "Post deleted successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "Post not found or error occurred.", error = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult EditPost(int id, [FromBody] PostDto editPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var postToUpdate = _modelMapper.MapPost(editPostDto);
                postToUpdate.PostID = id;

                var updatedPost = _editPostService.EditPost(postToUpdate);

                return Ok(updatedPost);
            }
            catch (Exception ex)
            {
                // Log the exception details here as needed
                return NotFound(new { message = "Post not found or error occurred.", error = ex.Message });
            }
        }
    }
}
