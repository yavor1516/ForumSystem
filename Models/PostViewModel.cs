using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ForumSystem.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public bool notAuthenticated { get; set; }

        public User User { get; set; }

        public string CommentContent {get;set;}

        public int registredUsers { get; set; }

        public int onlineUsers { get; set; }

    }
}
