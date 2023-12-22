using ForumSystem.Exceptions;
using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Models.DTO;
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
        private readonly IModelMapper _modelMapper;
        public FeedController(IForumDataService forumDataService , IModelMapper modelMapper)
        {
            _forumDataService = forumDataService;
            _modelMapper = modelMapper;
        }
        [HttpGet("{id}")]
        public IActionResult DeleteUserById(int id)
        {
             
            try
            {
                User user = _forumDataService.GetUserById(id);
                UserResponseDto userResponseDto = _modelMapper.MapUser(user);
                userResponseDto.posts = _forumDataService.ShowAllPosts().Where(x=>x.UserID == userResponseDto.UserID).ToList();
                return Ok(userResponseDto.posts);
                //_forumDataService.DeletePost(id);                
                //return Ok("We did it"); 
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
