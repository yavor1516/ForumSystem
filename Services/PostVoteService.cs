using ForumSystem.Exceptions;
using ForumSystem.Models;
using ForumSystem.Models.DTO;
using ForumSystem.Repositories;

namespace ForumSystem.Services
{
    public class PostVoteService : IPostVoteService
    {
        private readonly IPostRepository _postRepository;
        private readonly IVoteRepositorycs _voteRepositorycs;
        private readonly IUserDataService _userDataService;


		public PostVoteService(IPostRepository postRepository, IVoteRepositorycs voteRepositorycs, IUserDataService userDataService)
		{
			_postRepository = postRepository;
			_voteRepositorycs = voteRepositorycs;
			_userDataService = userDataService;
		}



		public void Dislike(int id, int value)
        {
            var post = _postRepository.GetPostByPostId(id);
            post.DownVote = value;
			
           
            _postRepository.Update(id, post);
           
        }

        public void Like(int id)
        {
            var post = _postRepository.GetPostByPostId(id);
            post.UpVote = _voteRepositorycs.GetPostUpVotes(id);

		
			post.DownVote = _voteRepositorycs.GetPostDownVotes(id);

			
			_postRepository.Update(id, post);
           
        }
		public VoteTable CreateVote(int postId , string username)
		{

			VoteTable existingVoteTable = _voteRepositorycs.GetVoteTableByPostIdAndUsername(postId, username);
			if (existingVoteTable != null)
			{
				UpdateVote(postId, username);

			}
			else
			{
				 VoteTable vote = new VoteTable()
            {
                User = _userDataService.GetByUsername(username),
                Post = _postRepository.GetPostByPostId(postId),
                liked = true,
                PostID = postId,
                views = 1,
                UserID = _userDataService.GetByUsername(username).UserID
			};
				_voteRepositorycs.CreateVote(vote);
				Like(postId);
				
			
				return vote;
			}

			return existingVoteTable;

		}

		public VoteTable UpdateVote(int postId, string username)
		{
			VoteTable existingVoteTable = _voteRepositorycs.GetVoteTableByPostIdAndUsername(postId, username);
			if (existingVoteTable == null)
			{
				throw new DuplicateEntityException($"vote doesnt exist!!!.");
			}

			if(existingVoteTable.liked == true)
			{
				VoteTable vote = new VoteTable()
				{
					User = _userDataService.GetByUsername(username),
					Post = _postRepository.GetPostByPostId(postId),
					liked = null,
					PostID = postId,
					views = 1,
					UserID = _userDataService.GetByUsername(username).UserID
				};
				vote.liked = null;

				_voteRepositorycs.UpdateVote(_voteRepositorycs.GetVoteTableByPostIdAndUsername(postId,username).VoteID, vote);
				Like(postId);
				
				
				return vote;
			}
			else
			{
				VoteTable vote = new VoteTable()
				{
					User = _userDataService.GetByUsername(username),
					Post = _postRepository.GetPostByPostId(postId),
					liked = true,
					PostID = postId,
					views = 1,
					UserID = _userDataService.GetByUsername(username).UserID
				};
				_voteRepositorycs.UpdateVote(_voteRepositorycs.GetVoteTableByPostIdAndUsername(postId, username).VoteID, vote);
				Like(postId);
			
				
				return vote;
			}
		


		}

		public int GetPostLikes(int postid)
		{
			return _voteRepositorycs.GetPostUpVotes(postid);
		}

		public int GetPostDisslikes(int postid)
		{
			return _voteRepositorycs.GetPostDownVotes(postid);
		}
	}
}
