using ForumSystem.Services;
using ForumSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ForumSystem.Controllers
{
    [ApiController]
    [Route("/createcomment")]
    public class CreateCommentController : Controller
    {
        private readonly ICreateCommentService _commentService;

        public CreateCommentController(ICreateCommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult CreateComment()
        {
            return View(new Comment());
        }
        [HttpPost]
        public ActionResult CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentService.CreateComment(comment);
                return RedirectToAction("Index", "Home");
            }

            return View(comment);
        }
    }
}

