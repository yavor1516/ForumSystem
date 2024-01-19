// AuthService.cs
using ForumSystem.Models.DTO;
using System.Security.AccessControl;

public class AuthService : IAuthService
{
    private string accessToken;

    public string GetAccessToken()
    {
        return accessToken;
    }

    public string SetAccessToken(string token)
    {
        accessToken = token;
        return accessToken;
    }
}
