using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ForumSystem.Controllers.Api
{
    [ApiController]
    [Route("/home")]
    public class HomePageController : ControllerBase
    {
        private readonly IForumDataService _forumDataService;

        public HomePageController(IForumDataService forumDataService)
        {
            _forumDataService = forumDataService;
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            try
            {
                var registeredUsersCount = _forumDataService.GetTotalUsersCount();
                var postsCount = _forumDataService.GetTotalPostsCount();
                var commentsCount = _forumDataService.GetTotalCommentsCount();
                var likesCount = _forumDataService.GetTotalLikesCount();
                var recentPosts = _forumDataService.GetRecentPosts(5); // vuvedi chislo za kolko recent posta da se pokajat

                var stats = new
                {
                    TotalRegisteredUsers = registeredUsersCount,
                    TotalPosts = postsCount,
                    TotalComments = commentsCount,
                    TotalLikes = likesCount,
                    RecentPosts = recentPosts 
                };

                return Ok(stats);
            }
            catch (Exception ex) 
            {
                
                return StatusCode(500, "An error occurred while retrieving statistics.");
            }
        }
    }
}
