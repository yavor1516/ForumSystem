using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IForumDataService
    {
     
        public User GetUserById(int id);
        public Post GetPostById(int id);
        public Comment GetCommentById(int id);
     
        public ICollection<User> GetAllUsers();
        public ICollection<Post> GetAllPosts(DateTime timeAgo);
        public ICollection<Comment> GetAllComments();
    }
}
