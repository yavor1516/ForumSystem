using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        [Key]
        public int PostID { get; set; } // Foreign Key
        [Key]
        public int UserID { get; set; } // Foreign Key
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }

        // Navigation properties
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
