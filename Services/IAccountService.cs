using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IAccountService
    {
       public User Register(User user);
       public User Login (User user);

    }
}
