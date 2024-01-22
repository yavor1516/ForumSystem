using ForumSystem.Exceptions;
using ForumSystem.Models;
using ForumSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ForumSystem.Repositories
{
	public class VoteRepositorycs : IVoteRepositorycs
	{
		private readonly ForumContext _dbcontext;
		private readonly IUserDataService _userDataService;
		public VoteRepositorycs(ForumContext forumContext, IUserDataService userDataService)
		{
			_dbcontext = forumContext;
			_userDataService = userDataService;
		}

		public ForumContext ForumContext { get; }

		public VoteTable CreateVote(VoteTable voteTale)
		{
			_dbcontext.Votes.Add(voteTale);
			_dbcontext.SaveChanges();
			return voteTale;
		}

		public IQueryable<VoteTable> GetAllVotesForPostId(int postId)
		{
			return _dbcontext.Votes.Where(x=>x.PostID == postId);
		}

		public int GetPostDownVotes(int postId)
		{
			return _dbcontext.Votes.Where(x => x.PostID == postId && x.liked == null).Count();
		}

		public int GetPostUpVotes(int postId)
		{
			return _dbcontext.Votes.Where(x => x.PostID == postId && x.liked != null).Count();
		}

		public VoteTable GetVoteById(int id)
		{
			return _dbcontext.Votes.FirstOrDefault(x => x.VoteID == id);
		}

		public VoteTable GetVoteTableByPostIdAndUsername(int postId, string username)
		{
			VoteTable vote = _dbcontext.Votes.FirstOrDefault(x => x.PostID == postId && x.UserID == _userDataService.GetByUsername(username).UserID);
			return vote ;
			
		}

		public VoteTable UpdateVote(int id, VoteTable comment)
		{
			VoteTable voteToUpdate = GetVoteById(id);
			voteToUpdate.liked = comment.liked;

			_dbcontext.SaveChanges();
			return voteToUpdate;
			
		}
	}
}
