using ForumSystem.Models;
using ForumSystem.Models.DTO;

namespace ForumSystem.Services
{
    public interface ICreateCommentService
    {
        public void CreateComment(CreateCommentDto commentDto,string username);

        public ICollection<Comment> GetCommentsByPostId(int postId);
    }
}
