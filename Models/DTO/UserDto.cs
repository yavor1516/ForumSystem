using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models.DTO
{
    public class UserDto
    {
        [Required]
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "The {0} field must be more than {1} characters.")]
        [MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "The {0} field must be a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MinLength(4, ErrorMessage = "The {0} field must be at least {1} characters long.")]
        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MinLength(4, ErrorMessage = "The {0} field must be at least {1} characters long.")]
        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string LastName { get; set; }

       
    }


}
