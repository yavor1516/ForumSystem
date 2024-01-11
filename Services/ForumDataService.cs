using ForumSystem.Exceptions;
using ForumSystem.Models;
using ForumSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ForumSystem.Services
{
    public class ForumDataService : IForumDataService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;

        public ForumDataService(IPostRepository postRepository, IUserRepository userRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
        }

        public void DeletePost(int id)
        {
            _postRepository.DeletePost(id);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public int GetTotalPostsCount()
        {
            return _postRepository.GetAllPosts().Count();
        }

        public int GetTotalUsersCount()
        {
            return _userRepository.GetAllUsers().Count();
        }

        public int GetTotalCommentsCount()
        {
            return _commentRepository.GetAllComments().Count();
        }
        public int GetTotalLikesCount()
        {
            return _postRepository.GetAllPosts().Sum(post => post.UpVote.GetValueOrDefault());
        }

        public IQueryable<Post> ShowAllPosts()
        {
            return _postRepository.GetAllPosts(); 
        }

        //IQueryable
        public IEnumerable<Post> GetRecentPosts(int numberOfRecentPosts)
        {


            return _postRepository.GetAllPosts()
                .OrderByDescending(post => post.PostDate)
                .Take(numberOfRecentPosts)
                .ToList();
        }

        public Post GetPostByPostId(int id)
        {
            return _postRepository.GetPostByPostId(id);
        }
    }
}
