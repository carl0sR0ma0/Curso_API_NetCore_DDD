using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CepEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Cep { get; set; } = string.Empty;

        [Required]
        [MaxLength(60)]
        public string Logradouro { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string Numero { get; set; } = string.Empty;
        public Guid MunicipioId { get; set; }
        public MunicipioEntity? Municipio { get; set; }
    }
}
