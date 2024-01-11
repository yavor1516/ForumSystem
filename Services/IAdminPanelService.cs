using ForumSystem.Models;

namespace ForumSystem.Services
{
    public interface IAdminPanelService
    {
        public User MakeUserAdmin(string username,string phoneNumber);
        public User BlockUser(string user);
        public User UnBlockUser(string user);
    }
}
