using ForumSystem.Models;
using ForumSystem.Models.DTO;

namespace ForumSystem.Helpers
{
    public interface IModelMapper
    {
        User MapUser(UserDto dto);
        UserResponseDto MapUser(User userModel);
        Post MapPost(PostDto dto);
    }
}
