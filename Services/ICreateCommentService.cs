using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface ICreateCommentService
    {
        public void CreateComment(Comment comment);
    }
}
