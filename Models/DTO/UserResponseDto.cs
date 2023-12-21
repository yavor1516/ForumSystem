namespace ForumSystem.Models.DTO
{
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOnline { get; set; }
        public bool IsBlocked { get; set; }
        public string PhoneNumber { get; set; }
     
    }

}
