using ForumSystem.Exceptions;
using ForumSystem.Models;
using ForumSystem.Repositories;
using Microsoft.Extensions.Options;

namespace ForumSystem.Services
{
    public class ForumDataService : IForumDataService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public ForumDataService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public void DeletePost(int id)
        {
            _postRepository.DeletePost(id);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public ICollection<Post> ShowAllPosts()
        {
            return _postRepository.GetAllPosts(); 
        }
    }
}
