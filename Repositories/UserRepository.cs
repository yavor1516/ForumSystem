using ForumSystem.Exceptions;
using ForumSystem.Models;

namespace ForumSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumContext _dbcontext;

        public UserRepository(ForumContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool BlockUser(int id)
        {
            if(_dbcontext.Users.FirstOrDefault(x => x.UserID == id) != null) //to do?
            {
                return true;
            }
            return false;
        }

        public User CreateUser(User user)
        {
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
            return user;
        }

        public ICollection<User> GetAllUsers()
        {
            return _dbcontext.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.Email == email);
            return user ?? throw new EntityNotFountException($"User with Email ={email} doesn't exist.");
        }

        public User GetUserByFirstName(string firstName)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.FirstName==firstName);
           return user ?? throw new EntityNotFountException($"User with First Name ={firstName} doesn't exist."); 
        }

        public User GetUserById(int id)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.UserID == id);
            return user?? throw new EntityNotFountException($"User with id={id} doesn't exist.");
        }

        public User GetUserByUsername(string username)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.Username == username);
            return user ?? throw new EntityNotFountException($"User with Username={username} doesn't exist");
        }

        public User UpdateUserAdmin(int id, User user) //???????
        {
            User userToUpdate=GetUserById(id);
            userToUpdate.IsAdmin = user.IsAdmin;
          //  _dbcontext.Update(userToUpdate);
            _dbcontext.SaveChanges();
            return userToUpdate;
        }
    }
}
