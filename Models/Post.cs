using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Models
{
    public class Post
    {
        
        public int ? PostID { get; set; }
        [ForeignKey("userID")]
        
        public int ? UserID { get; set; } // Foreign Key
        public User User { get; set; }
        
        public string ? Title { get; set; }
       
        public string ? Content { get; set; }
        
        public DateTime PostDate { get; set; }

        
        public int? UpVote { get; set; }
        public int? DownVote { get; set; }
        public bool? IsActive {  get; set; }//for migration
        public bool? IsPublic {  get; set; }//for migration

        // Navigation properties
        // public virtual User User { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
