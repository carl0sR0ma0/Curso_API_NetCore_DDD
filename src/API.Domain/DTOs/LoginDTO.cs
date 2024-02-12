using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email é campo obrigatório para o Login")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no mínimo {1} caracteres.")]
        public string Email { get; set; } = string.Empty;
    }
}
