using ForumSystem.Models;
using ForumSystem.Models.DTO;

namespace ForumSystem.Services
{
    public interface IAccountService
    {

       

        public User RegisterUser (UserDto userDTO);
        public User LoginUser(UserLoginDto userLoginDto);

        public string GenerateToken(User user);

    }
}
