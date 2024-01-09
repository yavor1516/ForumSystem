using ForumSystem.Models;
using ForumSystem.Models.DTO;
using ForumSystem.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ForumSystem.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }
        public Post CreatePost(PostDto postDTO, string userName)
        {
           Post post = new Post(){
               User = _userRepository.GetUserByUsername(userName),
               UserID = _userRepository.GetUserByUsername(userName).UserID,
              
               PostDate = DateTime.Now,
               Title = postDTO.Title,
               Content = postDTO.Content,
               IsPublic = postDTO.isPublic
               
           };
            _postRepository.CreatePost(post);
            return post;


        }
    }
}
