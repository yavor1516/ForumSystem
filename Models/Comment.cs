using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Models
{
    public class Comment
    {
        [Key]
        
        public int ? CommentID { get; set; }
        [ForeignKey("postID")]
        
        public int ? PostID { get; set; } // Foreign Key
        public virtual Post Post { get; set; }
        [ForeignKey("userID")]
        
        public int ? UserID { get; set; } // Foreign Key
        public User  User { get; set; }
      
        public string ? Content { get; set; }
  
        public DateTime CommentDate { get; set; }

        
       
       
    }
}
