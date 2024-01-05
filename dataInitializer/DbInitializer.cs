using ForumSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ForumSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ForumContext context)
        {
            context.Database.EnsureCreated(); // Ensure the database is created

            if (context.Users.Any() || context.Posts.Any() || context.Comments.Any())
            {
                return; // Database has been seeded
            }

            var users = new[]
 { 
    new User
    {
        Username = "john_doe",
        Email = "john.doe@example.com",
        FirstName = "John",
        LastName = "Doe",
        PasswordHash = new byte[] { 0x01, 0x02, 0x03 },
        IsAdmin = true,
        isOnline = true,
        isBlocked = false,
        phoneNumber = "1234567890",
        RegistrationDate = DateTime.Now.AddDays(-10),
    },
    new User
    {
        Username = "jane_smith",
        Email = "jane.smith@example.com",
        FirstName = "Jane",
        LastName = "Smith",
        PasswordHash = new byte[] { 0x04, 0x05, 0x06 },
        IsAdmin = false,
        isOnline = true,
        isBlocked = false,
        phoneNumber = "9876543210",
        RegistrationDate = DateTime.Now.AddDays(-9),
    },
    new User
    {
        Username = "alice_jones",
        Email = "alice.jones@example.com",
        FirstName = "Alice",
        LastName = "Jones",
        PasswordHash = new byte[] { 0x07, 0x08, 0x09 },
        IsAdmin = false,
        isOnline = true,
        isBlocked = false,
        phoneNumber = "5555555555",
        RegistrationDate = DateTime.Now.AddDays(-8),
    },
    new User
    {
        Username = "bob_smith",
        Email = "bob.smith@example.com",
        FirstName = "Bob",
        LastName = "Smith",
        PasswordHash = new byte[] { 0x0A, 0x0B, 0x0C },
        IsAdmin = false,
        isOnline = true,
        isBlocked = false,
        phoneNumber = "4444444444",
        RegistrationDate = DateTime.Now.AddDays(-7),
    },
    new User
    {
        Username = "emma_davis",
        Email = "emma.davis@example.com",
        FirstName = "Emma",
        LastName = "Davis",
        PasswordHash = new byte[] { 0x0D, 0x0E, 0x0F },
        IsAdmin = false,
        isOnline = true,
        isBlocked = false,
        phoneNumber = "3333333333",
        RegistrationDate = DateTime.Now.AddDays(-6),
    },
    new User
    {
        Username = "samuel_jackson",
        Email = "samuel.jackson@example.com",
        FirstName = "Samuel",
        LastName = "Jackson",
        PasswordHash = new byte[] { 0x10, 0x11, 0x12 },
        IsAdmin = false,
        isOnline = true,
        isBlocked = false,
        phoneNumber = "2222222222",
        RegistrationDate = DateTime.Now.AddDays(-5),
    },
    new User
    {
        Username = "olivia_smith",
        Email = "olivia.smith@example.com",
        FirstName = "Olivia",
        LastName = "Smith",
        PasswordHash = new byte[] { 0x13, 0x14, 0x15 },
        IsAdmin = false,
        isOnline = true,
        isBlocked = false,
        phoneNumber = "1111111111",
        RegistrationDate = DateTime.Now.AddDays(-4),
    },
    new User
    {
        Username = "charlie_johnson",
        Email = "charlie.johnson@example.com",
        FirstName = "Charlie",
        LastName = "Johnson",
        PasswordHash = new byte[] { 0x16, 0x17, 0x18 },
        IsAdmin = false,
        isOnline = true,
        isBlocked = false,
        phoneNumber = "9999999999",
        RegistrationDate = DateTime.Now.AddDays(-3),
    },
    new User
    {
        Username = "ava_davis",
        Email = "ava.davis@example.com",
        FirstName = "Ava",
        LastName = "Davis",
        PasswordHash = new byte[] { 0x19, 0x1A, 0x1B },
        IsAdmin = false,
        isOnline = true,
        isBlocked = false,
        phoneNumber = "8888888888",
        RegistrationDate = DateTime.Now.AddDays(-2),
    },
    new User
    {
        Username = "michael_jones",
        Email = "michael.jones@example.com",
        FirstName = "Michael",
        LastName = "Jones",
        PasswordHash = new byte[] { 0x1C, 0x1D, 0x1E },
        IsAdmin = false,
        isOnline = true,
        isBlocked = false,
        phoneNumber = "7777777777",
        RegistrationDate = DateTime.Now.AddDays(-1),
    }
};

            context.Users.AddRange(users);
            context.SaveChanges();
            // Add 10 Posts
            if (!context.Posts.Any())
            {
                var posts = new[]
                {
        new Post
        {
            UserID = 11,
            Title = "First Post",
            Content = "This is the content of the first post.",
            PostDate = DateTime.Now.AddDays(-10),
            UpVote = 20,
            DownVote = 5,
             IsPublic = true,
            IsActive = true,
        },
        new Post
        {
            UserID = 2,
            Title = "Second Post",
            Content = "This is the content of the second post.",
            PostDate = DateTime.Now.AddDays(-9),
            UpVote = 15,
            DownVote = 3,
             IsPublic = true,
            IsActive = true,
        },
        new Post
        {
            UserID = 3,
            Title = "Third Post",
            Content = "This is the content of the third post.",
            PostDate = DateTime.Now.AddDays(-8),
            UpVote = 18,
            DownVote = 7,
            IsPublic = true,
            IsActive = true,
        },
    };

                context.Posts.AddRange(posts);
                context.SaveChanges();
            }
            // Add 10 Comments
            if (!context.Comments.Any())
            {
                var comments = new[]
                {
        new Comment
        {
            PostID = 1,
            UserID = 1,
            Content = "This is a comment on the first post.",
            CommentDate = DateTime.Now.AddDays(-10),
        },
        new Comment
        {
            PostID = 2,
            UserID = 2,
            Content = "This is a comment on the second post.",
            CommentDate = DateTime.Now.AddDays(-9),
        },
        new Comment
        {
            PostID = 3,
            UserID = 3,
            Content = "This is a comment on the third post.",
            CommentDate = DateTime.Now.AddDays(-8),
        },
    
        // Add the remaining comments...
    };

                context.Comments.AddRange(comments);
                context.SaveChanges();
            }
        }
    }
}
