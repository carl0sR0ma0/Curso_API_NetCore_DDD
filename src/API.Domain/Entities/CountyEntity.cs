using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CountyEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; } = string.Empty;
        public int CodeIBGE { get; set; }
        
        [Required]
        public Guid UFId { get; set; }
        public UFEntity? UF { get; set; }

        public IEnumerable<ZipCodeEntity>? ZipsCode { get; set; }
    }
}
