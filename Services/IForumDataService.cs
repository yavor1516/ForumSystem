using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IForumDataService
    {
     public void DeletePost(int id);        
     public IQueryable<Post> ShowAllPosts();
        public IQueryable<Post> GetAllPostsByUsername(string username);
     public IEnumerable<Post> GetRecentPosts(int numberOfRecentPosts);

     public Post GetPostByPostId(int id);
     public User GetUserById(int id);
     public int GetTotalUsersCount();
     public int GetTotalPostsCount();
     public int GetTotalCommentsCount();
     public int GetTotalLikesCount();

    }
}
