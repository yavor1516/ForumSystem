using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ForumSystem.Controllers
{
    public class PostController : Controller
    {
        private readonly IForumDataService _forumDataService;
        private readonly ITokenReader _tokenReader;
        private readonly IUserDataService _userDataService;
        private readonly IEditPostService _editPostService;
        public PostController(IForumDataService forumDataService, ITokenReader tokenReader,IUserDataService userDataService, IEditPostService editPostService)
        {
            _forumDataService = forumDataService;
            _tokenReader = tokenReader;
            _userDataService = userDataService;
            _editPostService = editPostService;
        }
        [HttpPut]
        public IActionResult Delete(int itemId)
        {

            // Your deletion logic here using the itemId parameter
            var post = _editPostService.DeleteCommentById(itemId);
            // Redirect or return a response as needed
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult EditComment(int itemId, PostViewModel postview)
        {
            Comment updatedComment = _editPostService.GetCommentById(itemId);
            updatedComment.Content = postview.CommentContent;
            _editPostService.EditComment(itemId, updatedComment);
            // Your deletion logic here using the itemId parameter
            var post = _editPostService.DeleteCommentById(itemId);
            // Redirect or return a response as needed
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index(int id)
        {
            var cookie = HttpContext.Request.Cookies;
            var tokenAsText = cookie["access_token"];
            
         
            
            if (tokenAsText != null)
            {
                var user = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Name)?.Value;

                Post post = _forumDataService.GetPostByPostId(id);
                if (post.IsDeleted != true)
                {
                    var ViewModel = new PostViewModel()
                    {
                        Post = _forumDataService.GetPostByPostId(id),
                        notAuthenticated = true,
                        User = _userDataService.GetByUsername(user)

                    };
                    return View(ViewModel);
                }
            }
            else
            {
                Post post = _forumDataService.GetPostByPostId(id);
                if(post.IsPublic != false && post.IsDeleted != true)
                {
                    var ViewModel = new PostViewModel()
                    {
                        Post = _forumDataService.GetPostByPostId(id),
                        notAuthenticated = false

                    };
                    return View(ViewModel);
                }
              
            }

            return RedirectToAction("Index", "Home");

        }

    }
}
