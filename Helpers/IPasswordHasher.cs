namespace ForumSystem.Helpers
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
