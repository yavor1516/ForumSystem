using ForumSystem.Exceptions;
using ForumSystem.Models;

namespace ForumSystem.Services
{
    public class ForumDataService : IForumDataService
    {
        private readonly ForumContext _dbContext;

        public ForumDataService(ForumContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Comment> GetAllComments()
        {
            return _dbContext.Comments.ToList();
        }

        public ICollection<Post> GetAllPosts(DateTime timeAgo)
        {
            return _dbContext.Posts.ToList();
        }

        public ICollection<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _dbContext.Comments.FirstOrDefault(x => x.CommentID == id);
        }

        public Post GetPostById(int id)
        {
            return _dbContext.Posts.FirstOrDefault(x => x.PostID == id);
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.UserID == id);
        }
    }
}
