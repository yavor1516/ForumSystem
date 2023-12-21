using ForumSystem.Exceptions;
using ForumSystem.Models;
using ForumSystem.Repositories;
using Microsoft.Extensions.Options;

namespace ForumSystem.Services
{
    public class ForumDataService : IForumDataService
    {
        private readonly IPostRepository _postRepository;

        public ForumDataService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void DeletePost(int id)
        {
            _postRepository.DeletePost(id);
        }      

        public ICollection<Post> ShowAllPosts()
        {
            return _postRepository.GetAllPosts(); 
        }
    }
}
