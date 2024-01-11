using ForumSystem.Models;
using ForumSystem.Repositories;

namespace ForumSystem.Services
{
    public class PostVoteService : IPostVoteService
    {
        private readonly IPostRepository _postRepository;

        public PostVoteService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post Dislike(int id)
        {
            var post = _postRepository.GetPostByPostId(id);
            post.DownVote = post.DownVote + 1;
            if (post.DownVote == null)
            {
                post.DownVote = 1;
            }
            _postRepository.Update(id, post);
            return post;
        }

        public Post Like(int id)
        {
            var post = _postRepository.GetPostByPostId(id);
            post.UpVote = post.UpVote + 1;
            if (post.UpVote == null)
            {
                post.UpVote = 1;
            }
               
        
            _postRepository.Update(id, post);
            return post;
        }
    }
}
