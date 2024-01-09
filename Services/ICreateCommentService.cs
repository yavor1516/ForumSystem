using ForumSystem.Models;
using ForumSystem.Models.DTO;

namespace ForumSystem.Services
{
    public interface ICreateCommentService
    {
        public void CreateComment(CreateCommentDto commentDto);
    }
}
