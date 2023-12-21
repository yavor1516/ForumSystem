using ForumSystem.Exceptions;
using ForumSystem.Models;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
        public IActionResult DeletePostById(int id)
        {

            try
            {                
                _forumDataService.DeletePost(id);                
                return Ok("We did it"); 
            }
            catch (EntityNotFountException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("")]
        public IActionResult ShowFeed()
        {
            var posts =_forumDataService.ShowAllPosts();
            string text = "koment";
            foreach (var item in posts)
            {
                text += item.Title;
                text += item.Content;
                foreach (var comment in item.Comments)
                {
                    text += comment.Content;
                }                
            }            
            try
            {
                return Ok(text);
            }
            catch (EntityNotFountException ex)
            {
                
              return NotFound(ex.Message);
            }
            
        }
    }
}
