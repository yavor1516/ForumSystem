using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models.DTO
{
    public class PostDto
    {
        [Required]
        public int PostId {get; set;}
        [Required]
        public int UserId { get; set; }
        [Required(ErrorMessage = "The {0} field is required!")]
        [MinLength(16 , ErrorMessage = "The {0} field must be at least {1} characters long.")]
        [MaxLength(64, ErrorMessage = "The {0} field must be less than {1} characters long.")]
        public string Title { get; set;}
        [Required(ErrorMessage = "The {0} field is required!")]
        [MinLength(32, ErrorMessage = "The {0} field must be at least {1} characters long.")]
        [MaxLength(8192, ErrorMessage = "The {0} field must be less than {1} characters long.")]
        public string Content { get; set; }


        

    }
}
