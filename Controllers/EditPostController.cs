using ForumSystem.Exceptions;
using ForumSystem.Helpers;
using ForumSystem.Models.DTO;
using ForumSystem.Models;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ForumSystem.Responses;

namespace ForumSystem.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/feed/edit")]
    public class EditPostController:ControllerBase
    {
        private readonly IEditPostService _editPostService;
     
        public EditPostController(IEditPostService editPostService)
        {
            _editPostService = editPostService;
          
        }
     
        //[HttpGet("{id}")]
        //public IActionResult DeletePostById(int id)
        //{ 
        //    try
        //    {
        //        var user = User.FindFirst(ClaimTypes.Name)?.Value;
        //      if (user != null && _editPostService.GetPostById(id).User.Username == user.ToString())
        //        {
        //            _editPostService.DeletePost(id);
        //            return Ok(new { message = "Post deleted successfully." });
        //        }
        //        return Unauthorized();
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(new { message = "Post not found or error occurred.", error = ex.Message });
        //    }
        //}
        [HttpPut("{id}")]
        public IActionResult EditPost(int id, [FromBody] EditPostDTO editPostDto)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }
            try
            {
                var user = User.FindFirst(ClaimTypes.Name)?.Value;
                var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

                if (user != null && _editPostService.GetPostById(id).User.Username == user.ToString()|| userRole == "True")
                {
                    var post = _editPostService.EditPost(editPostDto,id);

                    return Ok();

                }
                return Unauthorized();
                
              
            }
            catch (Exception e)
            {
                return Conflict(new Exception("post doenst exist or You dont have rights to change it!!"));
            }
        }
    }
}
