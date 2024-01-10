using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ForumSystem.Models
{
    public class Comment
    {

        public int ? CommentID { get; set; }
        [ForeignKey("postID")]
        public int ? PostID { get; set; } // Foreign Key

        [ForeignKey("userID")]
        public int UserID { get; set; } // Foreign Key
     
      
        public string ? Content { get; set; }
  
        public DateTime CommentDate { get; set; }

        [AllowNull]
        public bool? isDeleted { get; set; } // This property allows nulls




    }
}
