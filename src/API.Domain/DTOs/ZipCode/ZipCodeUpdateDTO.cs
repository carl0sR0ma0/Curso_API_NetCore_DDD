using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.ZipCode
{
    public class ZipCodeUpdateDTO
    {
        [Required(ErrorMessage = "Id é campo Obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "CEP é campo Obrigatório")]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Logradouro é campo Obrigatório")]
        public string PublicPlace { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "Município é campo Obrigatório")]
        public Guid CountyId { get; set; }
    }
}
