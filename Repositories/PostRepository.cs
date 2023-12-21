using ForumSystem.Exceptions;
using ForumSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumSystem.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ForumContext _dbcontext;
        public PostRepository(ForumContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public ICollection<Post> GetAllPosts()
        {         
            var postsWithComments = _dbcontext.Posts.Include(p => p.Comments).ToList();

            return postsWithComments;
        }


        public Post CreatePost(Post post)
        {

            _dbcontext.Posts.Add(post);
            _dbcontext.SaveChanges();
            return post;
        }

        public void DeletePost(int id)
        {
            Post PostToUpdate = GetPostByPostId(id);  
        if (PostToUpdate.IsActive == true)
            {
                PostToUpdate.IsActive = false;
                _dbcontext.SaveChanges();
            }            
        }

        public Post GetPostByPostId(int id)
        {
            Post post = _dbcontext.Posts.FirstOrDefault(x => x.PostID == id);
            return post ?? throw new EntityNotFountException($"Post with ID {id} doesn't exist.");
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
