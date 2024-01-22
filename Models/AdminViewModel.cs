namespace ForumSystem.Models
{
    public class AdminViewModel
    {
        public ICollection<User> ? Users { get; set; }
        public string username { get; set; }
    }
}