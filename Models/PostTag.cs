namespace ForumSystem.Models
{
    public class PostTag
    {
        public int PostID { get; set; } // Foreign Key
        public int TagID { get; set; } // Foreign Key

        // Navigation properties
        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
