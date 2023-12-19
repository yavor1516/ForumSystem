namespace ForumSystem
{
    using ForumSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Builder;

    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) :
            base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        // public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            if (!optionsBuilder.IsConfigured)
            {
                // Configure the connection string here
                optionsBuilder.UseSqlServer("Your_Connection_String");
              

            }
        }
    }

}
