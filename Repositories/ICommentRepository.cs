using ForumSystem.Models;

namespace ForumSystem.Repositories
{
    public interface ICommentRepository
    {
        public Comment GetById(int id);
        public ICollection<Comment> GetAllComments();
        public Comment CreateComment(Comment comment);
        public Comment UpdateComment(int id,Comment comment);
        public bool DeleteComment(int id);
        public bool CommentExists(int id);//to ask
        
    }
}
