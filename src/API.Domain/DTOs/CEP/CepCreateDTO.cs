using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.CEP
{
    public class CepCreateDTO
    {
        [Required(ErrorMessage = "CEP é campo Obrigatório")]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "Logradouro é campo Obrigatório")]
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Município é campo Obrigatório")]
        public Guid MunicipioId { get; set; }
    }
}
