using ForumSystem.Models;

namespace ForumSystem.Repositories
{
    public interface IUserRepository
    {
        public User GetUserById(int id);
        public User GetUserByFirstName(string firstName);
        public User GetUserByUsername(string username);
        public User GetUserByEmail(string email);
        public ICollection<User> GetAllUsers();
        public User CreateUser(User user);
        public User UpdateUserAdmin(int id,User user);// to ask
        public bool BlockUser(int id);//to ask
    }
}
