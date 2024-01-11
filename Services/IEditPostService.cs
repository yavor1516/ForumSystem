﻿using ForumSystem.Models;
using ForumSystem.Models.DTO;

namespace ForumSystem.Services
{
    public interface IEditPostService
    {
        public Post EditPost(EditPostDTO editPostDTO, int id);
        public bool DeletePost(int id);

        public Post GetPostById(int id);
    }
}
