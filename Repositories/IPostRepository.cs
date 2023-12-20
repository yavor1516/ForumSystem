using ForumSystem.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace ForumSystem.Repositories
{
    public interface IPostRepository
    {
        public Post GetPostByPostId(int id);
        public ICollection<Post> GetAllPosts { get; }
        public Post CreatePost(Post post);
        public Post Update(int id, Post post);
        public bool DeletePost(int id);

    }
}
