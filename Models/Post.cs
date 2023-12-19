using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ForumSystem.Models
{
    public class Post
    {
        [NotNull]
        public int PostID { get; set; }
        [Key]
        [NotNull]
        public int UserID { get; set; } // Foreign Key
        public User User { get; set; }
        [NotNull]
        public string Title { get; set; }
        [NotNull]
        public string Content { get; set; }
        [NotNull]
        public DateTime PostDate { get; set; }

        
        public int UpVote { get; set; }
        public int DownVote { get; set; }

        // Navigation properties
       // public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
