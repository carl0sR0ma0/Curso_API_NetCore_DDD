namespace Domain.DTOs.CEP
{
    public class CepCreateResultDTO
    {
        public Guid Id { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public Guid MunicipioId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
