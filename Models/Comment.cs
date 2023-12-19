using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ForumSystem.Models
{
    public class Comment
    {
        [Key]
        [NotNull]
        public int CommentID { get; set; }
        [Key]
        [NotNull]
        public int PostID { get; set; } // Foreign Key
        public virtual Post Post { get; set; }
        [Key]
        [NotNull]
        public int UserID { get; set; } // Foreign Key
        public User User { get; set; }
        [NotNull]
        public string Content { get; set; }
        [NotNull]
        public DateTime CommentDate { get; set; }

        
       
       
    }
}
