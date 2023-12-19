using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models
{
    public class Post
    {
        public int PostID { get; set; }
        [Key]
        public int UserID { get; set; } // Foreign Key
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public int LikesCount { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
