using ForumSystem.Exceptions;
using ForumSystem.Helpers;
using ForumSystem.Models;
using ForumSystem.Models.DTO;
using ForumSystem.Repositories;
using ForumSystem.Responses;
using ForumSystem.Services.TokenGenerator;
using System.Text;

namespace ForumSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserDataService _userDataService;
        private readonly IPasswordHasher _passwordHasher;
        
        private readonly AccessTokenGenerator _tokenGenerator;
        public AccountService(IUserDataService userDataService, IPasswordHasher passwordHasher, AccessTokenGenerator tokenGenerator)
        {
            _userDataService = userDataService;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

     

        public string GenerateToken(User user)
        {
            string accessToken = _tokenGenerator.GenerateToken(user);
            return accessToken;
        }

        public User LoginUser(UserLoginDto userLoginDto)
        {
            User user = _userDataService.GetByUsername(userLoginDto.Username);
            if (user == null)
            {
                throw new Exception($"Wrong credentials!!");
            }
            bool isCorrectPassword = _passwordHasher.VerifyPassword(userLoginDto.Password, Encoding.UTF8.GetString(user.PasswordHash));
            if (!isCorrectPassword)
            {
                throw new Exception($"Wrong credentials!!");
            }
            return user;
        }

        public User RegisterUser(UserDto userDTO)
        {
            User existingUserByEmail = _userDataService.GetByEmail(userDTO.Email);
            if (existingUserByEmail != null)
            {
                throw new DuplicateEntityException($"Account with email: {existingUserByEmail.Email} already exist!.");
            }

            User existingUserByUsername = _userDataService.GetByUsername(userDTO.Username);
            if (existingUserByUsername != null)
            {
                throw new DuplicateEntityException($"Account with username: {existingUserByUsername.Username} already exist!.");
              
            }

            string passwordHash = _passwordHasher.HashPassword(userDTO.Password);
            User registerUser = new User()
            {
                Email = userDTO.Email,
                Username = userDTO.Username,
                PasswordHash = Encoding.UTF8.GetBytes(passwordHash),
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
            };

            _userDataService.CreateUser(registerUser);

            return registerUser;
        }
    }
}
