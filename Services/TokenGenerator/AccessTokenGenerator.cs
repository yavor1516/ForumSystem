using ForumSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ForumSystem.Services.TokenGenerator
{
    public class AccessTokenGenerator
    {
        public string GenerateToken(User user)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2HBn8feBYdw7MoYrN5TjVo80Px4dRWV3KZyhIVwumJtgBXXa1x4feQKkVuIqDWI7_v9kUlgGzerPB5iVfIUj9h_s6Rvp_jdlgmBLLMm9TkPgFhiLFxZ6n7BzhTSEa7zLDZvwZETggVqv5GWZNPUdMVL-yfJ4cM7UKVejVlK0eVk"));
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim("id",user.UserID.ToString()),
                 new Claim(ClaimTypes.Email,user.Email),
                 new Claim(ClaimTypes.Name,user.Username),
                 new Claim(ClaimTypes.Role,user.IsAdmin.ToString()),

            };
            JwtSecurityToken token = new JwtSecurityToken("http://localhost:5272",
                "http://localhost:5272",
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(30),
                credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
