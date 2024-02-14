using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.CEP
{
    public class CepUpdateDTO
    {
        [Required(ErrorMessage = "Id é campo Obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "CEP é campo Obrigatório")]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "Logradouro é campo Obrigatório")]
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "Município é campo Obrigatório")]
        public Guid MunicipioId { get; set; }
    }
}
