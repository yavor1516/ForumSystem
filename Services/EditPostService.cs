using ForumSystem.Models;
using ForumSystem.Models.DTO;
using ForumSystem.Repositories;

namespace ForumSystem.Services
{
    public class EditPostService:IEditPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        public EditPostService(IPostRepository editPostService,ICommentRepository commentRepository) 
        { 
            _postRepository = editPostService;
            _commentRepository = commentRepository;
        }
        public Post EditPost(EditPostDTO editPostDTO , int Postid) 
        {
            var existingPost = _postRepository.GetPostByPostId(Postid);
            if (existingPost.PostID == null)
            {
                throw new Exception("Post not found");
            }

            existingPost.Title = editPostDTO.Title;
            existingPost.Content = editPostDTO.Content;
            existingPost.IsPublic = editPostDTO.isPublic;

            return _postRepository.Update((int)existingPost.PostID, existingPost); ;
        }
        public bool DeletePost(int id)
        {
            _postRepository.DeletePost(id);
            return true;
        }

        public Post GetPostById(int id)
        {
            return _postRepository.GetPostByPostId(id);
        }

        public Comment GetCommentById(int id)
        {
            return _commentRepository.GetCommentById(id);
        }

        public Comment DeleteCommentById(int id)
        {
            return _commentRepository.DeleteComment(id);
        }

        public Comment EditComment(int id, Comment comment)
        {
            return _commentRepository.UpdateComment(id,comment);
        }
    }
}
