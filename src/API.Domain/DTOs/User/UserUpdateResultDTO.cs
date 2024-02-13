namespace Domain.DTOs.User
{
    public class UserUpdateResultDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime UpdateAt { get; set; }
    }
}
