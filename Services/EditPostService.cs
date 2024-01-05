using ForumSystem.Models;
using ForumSystem.Repositories;

namespace ForumSystem.Services
{
    public class EditPostService:IEditPostService
    {
        private readonly IPostRepository _postRepository;
        public EditPostService(IPostRepository editPostService) 
        { 
            _postRepository = editPostService;
        }
        public Post EditPost(Post post) 
        {
            var existingPost = _postRepository.GetPostByPostId((int)post.PostID);
            if (existingPost.PostID == null)
            {
                throw new Exception("Post not found");
            }

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;

            _postRepository.Update((int)existingPost.PostID,post);

            return existingPost;
        }
        public void DeletePost(int id)
        {
            _postRepository.DeletePost(id);
        }

        public Post GetPostById(int id)
        {
            return _postRepository.GetPostByPostId(id);
        }
    }
}
