using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.User
{
    public class UserUpdateDTO
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no mínimo {1} caracteres.")]
        public string Email { get; set; } = string.Empty;
    }
}
