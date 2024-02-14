using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class MunicipioEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; } = string.Empty;
        public int CodeIBGE { get; set; }
        
        [Required]
        public Guid UFId { get; set; }
        public UFEntity? UF { get; set; }

        public IEnumerable<CepEntity>? Ceps { get; set; }
    }
}
