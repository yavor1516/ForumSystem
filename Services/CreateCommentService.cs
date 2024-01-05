using ForumSystem.Models;
using ForumSystem.Repositories;

namespace ForumSystem.Services
{
    public class CreateCommentService:ICreateCommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CreateCommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public void CreateComment(Comment comment)
        {
           _commentRepository.CreateComment(comment);
        }
    }
}
