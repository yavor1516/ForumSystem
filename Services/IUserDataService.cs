using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IUserDataService
    {
        public User GetByEmail(string email);
        public User GetByUsername(string username);

        public User CreateUser(User user);
    }
}
