using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models.DTO
{
    public class EditPostDTO
    {
      
        [MinLength(16, ErrorMessage = "The {0} field must be at least {1} characters long.")]
        [MaxLength(64, ErrorMessage = "The {0} field must be less than {1} characters long.")]
        public string Title { get; set; }
     
        [MinLength(32, ErrorMessage = "The {0} field must be at least {1} characters long.")]
        [MaxLength(8192, ErrorMessage = "The {0} field must be less than {1} characters long.")]
        public string Content { get; set; }

        public bool isPublic { get; set; }

    }
}
