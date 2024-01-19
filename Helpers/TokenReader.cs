using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ForumSystem.Helpers
{
    public class TokenReader : ITokenReader
    {
       
        public ClaimsPrincipal GetToken(string tokenAsText)
        {
            var tokenTest = new JwtSecurityTokenHandler().ReadJwtToken(tokenAsText);
            var identity = new ClaimsPrincipal(new ClaimsIdentity(tokenTest.Claims));
            return identity;
        }
    }
}
