namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
    }
}
