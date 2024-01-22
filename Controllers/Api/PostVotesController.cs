using ForumSystem.Models.DTO;
using ForumSystem.Responses;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;

namespace ForumSystem.Controllers.Api
{
    [ApiController]
    [Route("/vote")]
    public class PostVotesController : ControllerBase
    {
        private readonly IPostVoteService _postVoteService;

        public PostVotesController(IPostVoteService postVoteService)
        {
            _postVoteService = postVoteService;
        }

        [HttpPut("like/{id}")]
        public IActionResult LikePost(int id, int value)
        {
            try
            {
                // var user = User.FindFirst(ClaimTypes.Name)?.Value;
                // var userRole = User.FindFirst(ClaimTypes.Role)!.Value;
                return Ok();
              

                //if (user != null && _editPostService.GetPostById(id).User.Username == user.ToString() || userRole == "True")
                //{
                //    var post = _editPostService.EditPost(editPostDto, id);

                //    return Ok();

                //}
                return Conflict();


            }
            catch (Exception e)
            {
                return Conflict(new Exception("post doenst exist or You dont have rights to change it!!"));
            }
        }
        [HttpPut("dislike/{id}")]
        public IActionResult DislikePost(int id, int value)
        {
            try
            {
                // var user = User.FindFirst(ClaimTypes.Name)?.Value;
                // var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        

                    return Ok();
              


                //if (user != null && _editPostService.GetPostById(id).User.Username == user.ToString() || userRole == "True")
                //{
                //    var post = _editPostService.EditPost(editPostDto, id);

                //    return Ok();

                //}
                return Conflict();


            }
            catch (Exception e)
            {
                return Conflict(new Exception("post doenst exist or You dont have rights to change it!!"));
            }
        }
    }
}
