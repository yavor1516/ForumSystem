using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IAccountService
    {
       public User GetByEmail (string email);
       public User GetByUsername (string username);

       public User CreateUser (User user);

    }
}
