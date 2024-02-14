using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Municipio
{
    public class MunicipioUpdateDTO
    {
        [Required(ErrorMessage = "Id é campo Obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome do município é campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Nome do município deve ter máximo {1} caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE inválido")]
        public int CodeIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é campo Obrigatório")]
        public Guid UFId { get; set; }
    }
}
