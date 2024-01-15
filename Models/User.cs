using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ForumSystem.Models
{
    
    public class User
    {
       
        [Key]
       
        public int UserID { get; set; }
        
        public string ? Username { get; set; }
       
        [EmailAddress]
        public string ? Email { get; set; }
       
        [Required]
        [MinLength(4)]
        [MaxLength(32)]
        public string ? FirstName { get; set; }
        
        [Required]
        [MinLength(4)]
        [MaxLength(32)]
        public string ? LastName { get; set; }
        
        public byte[] PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public bool isOnline { get; set; }
        public bool isBlocked { get; set; }
        [AllowNull]
        public string ? phoneNumber { get; set; } // This property allows nulls
        public DateTime RegistrationDate { get; set; }

       // public string? AvatarUrl { get; set; } TODO
       // public string Bio { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
