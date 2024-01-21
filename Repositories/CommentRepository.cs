using ForumSystem.Exceptions;
using ForumSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ForumSystem.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumContext _dbcontext;
        public CommentRepository(ForumContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool CommentExists(int id)
        {
            return _dbcontext.Comments.Any(x => x.CommentID == id);
        }

        public Comment CreateComment(Comment comment)
        {
            _dbcontext.Comments.Add(comment);
            var postToCreateComment = _dbcontext.Posts.FirstOrDefault(x => x.PostID == comment.PostID);
            postToCreateComment.Comments.Add(comment);
            _dbcontext.SaveChanges();
            return comment;
        }

        public Comment DeleteComment(int id)
        {
            var comment = _dbcontext.Comments.Find(id);// to do
            comment.isDeleted = true;
            _dbcontext.Comments.Update(comment);
            
            _dbcontext.SaveChanges();
            return comment ?? throw new EntityNotFountException($"Comment with id{id} doesn't exist.");
        }

        public ICollection<Comment> GetAllComments()
        {
            return _dbcontext.Comments.ToList();
        }

        //public ICollection<Comment> GetAllCommentsInPostWithId(int id)
        //{
        //    return 
        //        //_dbcontext.Posts.FirstOrDefault(x => x.PostID == id).Comments;
        //        // return _dbcontext.Posts.Include(p => p.Comments).Include(u=>u.User).ToList();
        //}

        public Comment GetCommentById(int id)
        {
            Comment comment = _dbcontext.Comments.SingleOrDefault(x=> x.CommentID == id);
            return comment ?? throw new EntityNotFountException($"Comment with id{id} doesn't exist.");
        }

        public Comment UpdateComment(int id, Comment comment)
        {
            Comment commentToUpdate=GetCommentById(id);
            commentToUpdate.Content = comment.Content;
            
            _dbcontext.SaveChanges(); 
            return commentToUpdate;
        }
    }
}
