using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UFEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Initials { get; set; } = string.Empty;

        [Required]
        [MaxLength(45)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<CountyEntity>? Counties { get; set; }
    }
}
