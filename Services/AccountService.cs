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
        public User Login(User user)
        {
            return user; //TODO
        }

        public User Register(User user)
        {
            return _userRepository.CreateUser(user);
        }
    }
}
