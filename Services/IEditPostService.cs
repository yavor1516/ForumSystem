using ForumSystem.Models;
using ForumSystem.Models.DTO;

namespace ForumSystem.Services
{
    public interface IEditPostService
    {
        public Post EditPost(EditPostDTO editPostDTO, int id);
        public bool DeletePost(int id);

        public Post GetPostById(int id);

        public Comment GetCommentById(int id);
        public Comment DeleteCommentById(int id);

        public Comment EditComment(int id, Comment comment);
    }
}
