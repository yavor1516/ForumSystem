using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ForumSystem.Helpers
{
    public interface ITokenReader
    {
        public ClaimsPrincipal GetToken(string tokenAsText);
       

    }
}
