using ForumSystem.Models;

namespace ForumSystem.Repositories
{
    public class PostRepository : IPostRepository
    {
        public ICollection<Post> GetAllPosts => throw new NotImplementedException();

        public Post CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public bool DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public Post GetPostByPostId(int id)
        {
            throw new NotImplementedException();
        }

        public bool PostExists(string title)
        {
            throw new NotImplementedException();
        }

        public Post Update(int id, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
