using ForumSystem.Models;
using System.Collections.Generic;

namespace ForumSystem.Models
{
    // ProfileViewModel will contain all the data necessary for displaying a user profile
    public class ProfileViewModel
    {
        
        public User User { get; set; }
        public IEnumerable<Post> Posts { get; set; }

        public int TotalUsers { get; set; }
        public bool notAuthenticated { get; set; }


    }
    
}
