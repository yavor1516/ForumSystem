using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IPostVoteService
    {
        public Post Like(int id);
        public Post Dislike(int id);
    }
}
