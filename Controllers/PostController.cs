using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Models.DTO;
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
        private readonly ICreateCommentService _createCommentService;
        private readonly IPostVoteService _postVoteService;
       
		public PostController(IForumDataService forumDataService, ITokenReader tokenReader, IUserDataService userDataService, IEditPostService editPostService, ICreateCommentService createCommentService, IPostVoteService postVoteService)
		{
			_forumDataService = forumDataService;
			_tokenReader = tokenReader;
			_userDataService = userDataService;
			_editPostService = editPostService;
			_createCommentService = createCommentService;
			_postVoteService = postVoteService;
		}
		[HttpPost]
        public IActionResult Delete(int itemId)
        {

            // Your deletion logic here using the itemId parameter
            var post = _editPostService.DeleteCommentById(itemId);
            // Redirect or return a response as needed
            return RedirectToAction("Index", "Home");
        }


		[HttpPost]
        //public IActionResult EditComment(int itemId, PostViewModel postview)
        public IActionResult EditComment([FromForm] EditedCommentModel model)
        {
			Comment updatedComment = _editPostService.GetCommentById(model.CommentID);
            updatedComment.Content = model.Content ?? "noupdate";// postview.CommentContent;
            _editPostService.EditComment(model.CommentID, updatedComment);

			// Redirect or return a response as needed
			return RedirectToAction($"{model.PostId}");
		}
        [HttpPost]
        public IActionResult CreateComment([FromForm] CreateCommentDto model)
        {
            var cookie = HttpContext.Request.Cookies;
            var tokenAsText = cookie["access_token"];

            if (tokenAsText != null)
            {
                var user = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Name)?.Value;
                var userisBlocked = User.FindFirst(ClaimTypes.UserData)?.Value;
                if (userisBlocked != "True")
                {
                    _createCommentService.CreateComment(model, user);

					return RedirectToAction($"{model.PostID}");

				}
               
                //  updatedComment.Content = model.Content ?? "noupdate";// postview.CommentContent;
                //_editPostService.EditComment(model.CommentID, updatedComment);
            }
            return RedirectToAction("Index", "Home");
            // Redirect or return a response as needed

        }
        [HttpPost]
        public IActionResult Vote([FromForm] CreateVote model)
        {
			var cookie = HttpContext.Request.Cookies;
			var tokenAsText = cookie["access_token"];

			if (tokenAsText != null)
			{
				var user = _tokenReader.GetToken(tokenAsText).FindFirst(ClaimTypes.Name)?.Value;
				var userisBlocked = User.FindFirst(ClaimTypes.UserData)?.Value;
				if (userisBlocked != "True")
				{
                    //_createCommentService.CreateComment(model, user);
                    _postVoteService.CreateVote(model.PostId, model.UserId);
					return RedirectToAction($"{model.PostId}");

				}

				//  updatedComment.Content = model.Content ?? "noupdate";// postview.CommentContent;
				//_editPostService.EditComment(model.CommentID, updatedComment);
			}
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
