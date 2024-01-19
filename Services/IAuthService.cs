using ForumSystem.Models.DTO;

public interface IAuthService
{
    string SetAccessToken(string token);

    string GetAccessToken();
}