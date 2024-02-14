namespace Domain.DTOs.CEP
{
    public class CepUpdateResultDTO
    {
        public Guid Id { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public Guid MunicipioId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
