namespace ForumSystem
{
    using ForumSystem.Models;
    using Microsoft.EntityFrameworkCore;


    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) :
            base(options)
        {
        }

        public DbSet<User> ? Users { get; set; }
        public DbSet<Post> ? Posts { get; set; }
        public DbSet<Comment> ? Comments { get; set; }
        public DbSet<Tag> ? Tags { get; set; }
        // public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();
        }
       
    }

}
