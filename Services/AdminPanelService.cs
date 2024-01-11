using ForumSystem.Models;
using ForumSystem.Repositories;

namespace ForumSystem.Services
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly IUserRepository _userRepository;

        public AdminPanelService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User BlockUser(string user)
        {
            var userToBLock = _userRepository.GetUserByUsername(user);
            userToBLock.isBlocked = true;
            _userRepository.UpdateUser(userToBLock);
            return userToBLock;
            
        }

        public User MakeUserAdmin(string username, string phoneNumber)
        {
            var userToAdmin = _userRepository.GetUserByUsername(username);
            userToAdmin.IsAdmin = true;
            _userRepository.UpdateUser(userToAdmin);
            return userToAdmin;
        }

        public User UnBlockUser(string user)
        {
            var userToBLock = _userRepository.GetUserByUsername(user);
            userToBLock.isBlocked = false;
            _userRepository.UpdateUser(userToBLock);
            return userToBLock;

        }
    }
}
