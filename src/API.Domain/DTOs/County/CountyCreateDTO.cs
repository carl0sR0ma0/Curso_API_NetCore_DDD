using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.County
{
    public class CountyCreateDTO
    {
        [Required(ErrorMessage = "Nome do município é campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Nome do município deve ter máximo {1} caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE inválido")]
        public int CodeIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é campo Obrigatório")]
        public Guid UFId { get; set; }
    }
}
