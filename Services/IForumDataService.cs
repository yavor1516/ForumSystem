using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IForumDataService
    {
     public void DeletePost(int id);        
     public ICollection<Post> ShowAllPosts();
     public IEnumerable<Post> GetRecentPosts(int numberOfRecentPosts);
     public User GetUserById(int id);
     public int GetTotalUsersCount();
     public int GetTotalPostsCount();
     public int GetTotalCommentsCount();
     public int GetTotalLikesCount();

    }
}
