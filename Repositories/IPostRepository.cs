﻿using ForumSystem.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace ForumSystem.Repositories
{
    public interface IPostRepository
    {
        public IQueryable<Post> GetPostsByUserId(int userId);
        public Post GetPostByPostId(int id);
        public bool PostExists(string title);//to ask
        public IQueryable<Post> GetAllPosts();
        public Post CreatePost(Post post);
        public Post Update(int id, Post post);
        public void DeletePost(int id);
    }
}
