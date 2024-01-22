namespace ForumSystem.Models
{
    public class AdminViewModel
    {
        public ICollection<User> ? Users { get; set; }
        public User user { get; set; }
        public string username { get; set; }
        public int registredUsers { get; set; }

        public int onlineUsers { get; set; }
    }
}