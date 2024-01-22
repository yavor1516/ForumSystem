using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IPostVoteService
    {
        public void Like(int id);
        public void Dislike(int id,int value);

        public VoteTable CreateVote(int postId, string username);

        public VoteTable UpdateVote(int postId, string username);

        public int GetPostLikes(int postid);
        public int GetPostDisslikes (int postid);
    }
}
