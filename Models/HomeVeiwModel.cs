namespace ForumSystem.Models
{
    public class HomeVeiwModel
    { 
        public IQueryable<Post> Posts { get; set; }
        public int registredUsers { get; set; }

        public int onlineUsers { get; set; }

        public bool notAuthenticated { get; set; }
    }
}
