using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string TagName { get; set; }
        [ForeignKey("postID")]

        public int? PostID { get; set; } // Foreign Key

        // Navigation property

    }
}
