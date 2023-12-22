using ForumSystem.Models;
using ForumSystem.Models.DTO;

namespace ForumSystem.Helpers
{
    public class ModelMapper : IModelMapper
    {
        public User MapUser(UserDto dto)
        {
            return new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Username = dto.Username,
            };
        }

        public UserResponseDto MapUser(User userModel)
        {
            return new UserResponseDto
            {
                UserID = (int)userModel.UserID,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Username = userModel.Username,
                Email = userModel.Email,
                IsBlocked = userModel.isBlocked,
                IsOnline = userModel.isOnline,
                PhoneNumber = userModel.phoneNumber
            };
        }
        public Post MapPost(PostDto dto)
        {
            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content
            };
            return post;
        }
    }
}
