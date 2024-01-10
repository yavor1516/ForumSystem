using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models.DTO
{
    public class CreateCommentDto
    {
        [Required(ErrorMessage = "The {0} field is required!")]
        public int? PostID { get; set; } // ThePostId that is holding the comment
        [Required(ErrorMessage = "The {0} field is required!")]

        public string Content { get; set; }
     

    }
}
