using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IForumDataService
    {
     public void DeletePost(int id);        
     public ICollection<Post> ShowAllPosts();
     
    }
}
