using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ForumSystem.Models
{
	public class VoteTable
	{

		[Key]
		public int VoteID { get; set; }

		[ForeignKey("userID")]

		public int? UserID { get; set; } // Foreign Key
		public User User { get; set; }

		[ForeignKey("postID")]

		public int? PostID { get; set; } // Foreign Key
		public Post Post { get; set; }
		[AllowNull]
		public bool? liked { get; set; }

		[AllowNull]
		public int? views { get; set; }

	}
}
