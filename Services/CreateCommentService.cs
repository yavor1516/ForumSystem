using ForumSystem.Models;
using ForumSystem.Models.DTO;
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
        public void CreateComment(CreateCommentDto commentDto)
        {
            var comment = new Comment
            {
                PostID = commentDto.PostID,
                UserID = commentDto.UserID,
                Content = commentDto.Content,
                CommentDate = commentDto.CommentDate ?? DateTime.UtcNow
            };

            _commentRepository.CreateComment(comment);
        }
    }
}
