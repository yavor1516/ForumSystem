using ForumSystem.Models;
using ForumSystem.Models.DTO;

namespace ForumSystem.Services
{
    public interface IPostService
    {
       public Post CreatePost(PostDto postDTO, string userName);
       
    }
}
