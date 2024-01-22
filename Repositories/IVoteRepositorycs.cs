using ForumSystem.Models;

namespace ForumSystem.Repositories
{
	public interface IVoteRepositorycs
	{
		public VoteTable CreateVote(VoteTable voteTale);
		public VoteTable GetVoteById(int id);
		//public VoteTable GetCommentVotesByPostId(int id);
		public IQueryable<VoteTable> GetAllVotesForPostId(int postId);
		
		public VoteTable GetVoteTableByPostIdAndUsername(int postId, string username);
		public VoteTable UpdateVote(int id, VoteTable comment);

		public int GetPostUpVotes(int postId);
		public int GetPostDownVotes(int postId);


	}
}
