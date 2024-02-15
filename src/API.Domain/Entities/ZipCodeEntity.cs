using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ZipCodeEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(60)]
        public string PublicPlace { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string Number { get; set; } = string.Empty;
        public Guid CountyId { get; set; }
        public CountyEntity? County { get; set; }
    }
}
