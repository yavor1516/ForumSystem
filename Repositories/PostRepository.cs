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
        //
        //IQueryable<Post>
        public IQueryable<Post> GetAllPosts()
        {
            return _dbcontext.Posts.Where(x=>x.IsDeleted == null || false).Include(p => p.Comments).Include(u=>u.User);
        }

        public Post CreatePost(Post post)
        {
            _dbcontext.Posts.Add(post);
            _dbcontext.SaveChanges();
            return post;
        }

        public void DeletePost(int id)
        {
            var postToDelte = GetPostByPostId(id);
            if (postToDelte != null && postToDelte.IsDeleted != true)    //to do
            {
                postToDelte.IsDeleted = true;
                _dbcontext.Update(postToDelte);
                _dbcontext.SaveChanges();
            }

           
          
            //var postToUpdate = GetPostByPostId(id);
            //if (postToUpdate != null && postToUpdate.IsActive)    //to do
            //{
            //    postToUpdate.IsActive = false;
            //    _dbcontext.SaveChanges();
            //}
        }

        public Post GetPostByPostId(int id)
        {
            var db = _dbcontext.Posts.Where(x=>x.IsDeleted == null || false).Include(p => p.Comments).Include(u => u.User).ToList();
            var post = db.FirstOrDefault(x => x.PostID == id);
           
           
            return post ?? throw new EntityNotFountException($"Post with ID {id} doesn't exist.");
        }

        public bool PostExists(string title)
        {
            return _dbcontext.Posts.Any(p => p.Title == title);
        }

        public Post Update(int id, Post updatedPost)
        {
          
                _dbcontext.SaveChanges();
                return updatedPost;
        

         
        }
    }

}
