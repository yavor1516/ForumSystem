using ForumSystem.Models;
using ForumSystem.Models.DTO;
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
