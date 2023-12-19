using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ForumSystem.Models
{
    
    public class User
    {
        [Key]
        [NotNull]
        public int UserID { get; set; }
        [NotNull]
        public string Username { get; set; }
        [NotNull]
        [EmailAddress]
        public string Email { get; set; }
        [NotNull]
        [Required]
        [MinLength(4)]
        [MaxLength(32)]
        public string FirstName { get; set; }
        [NotNull]
        [Required]
        [MinLength(4)]
        [MaxLength(32)]
        public string LastName { get; set; }
        [NotNull]
        public byte[] PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public bool isOnline { get; set; }
        public bool isBlocked { get; set; }
        public string phoneNumber { get; set; }
        [NotNull]
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
