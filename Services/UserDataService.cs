using ForumSystem.Models;
using ForumSystem.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ForumSystem.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserRepository _userRepository;
        public UserDataService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }
        public User CreateUser(User user)
        {

            return _userRepository.CreateUser(user);
        }

    }
}
