using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IEditPostService
    {
        public Post EditPost(Post post);
        public void DeletePost(int id);

        public Post GetPostById(int id);
    }
}
