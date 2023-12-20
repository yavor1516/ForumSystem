using ForumSystem.Exceptions;
using ForumSystem.Models;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Controllers
{
    [ApiController]
    [Route("/feed")]
    public class FeedController : ControllerBase
    {
        private readonly IForumDataService _forumDataService;

        public FeedController(IForumDataService forumDataService)
        {
            _forumDataService = forumDataService;
        }
        [HttpGet("{id}")]
        public IActionResult GetPostLikesById(int id)
        {
            try
            {
                var upvotes = _forumDataService.GetPostById(id).UpVote;

                return Ok(upvotes);
            }
            catch (EntityNotFountException e)
            {
                return NotFound(e.Message);
            }
        }

        //[HttpGet("")]
        //public IActionResult ShowFeed()
        //{
        //    var comment = new Comment();
        //    comment.Content = "kurchio";
        //    var text = comment.Content;
        //    try
        //    {
        //        return Ok(text);
        //    }
        //    catch (EntityNotFountException ex)
        //    {

        //        return NotFound(ex.Message);
        //    }
            
        //}
    }
}
