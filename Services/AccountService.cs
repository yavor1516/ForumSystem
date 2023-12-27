using ForumSystem.Models;
using ForumSystem.Repositories;

namespace ForumSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public User GetByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }
    }
}
