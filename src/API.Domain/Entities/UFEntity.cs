using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UFEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; } = string.Empty;

        [Required]
        [MaxLength(45)]
        public string Nome { get; set; } = string.Empty;

        public IEnumerable<MunicipioEntity>? Municipios { get; set; }
    }
}
