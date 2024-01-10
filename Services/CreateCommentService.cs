using ForumSystem.Models;
using ForumSystem.Models.DTO;
using ForumSystem.Repositories;

namespace ForumSystem.Services
{
    public class CreateCommentService:ICreateCommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public CreateCommentService(ICommentRepository commentRepository, IUserRepository userRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }
        public void CreateComment(CreateCommentDto commentDto , string username)
        {
            var comment = new Comment
            {
                PostID = commentDto.PostID,
                UserID = _userRepository.GetUserByUsername(username).UserID,
                Content = commentDto.Content,
                CommentDate = DateTime.UtcNow
            };

            _commentRepository.CreateComment(comment);
        }

        public ICollection<Comment> GetCommentsByPostId(int postId)
        {
            return _postRepository.GetPostByPostId(postId).Comments;
        }
    }
}
