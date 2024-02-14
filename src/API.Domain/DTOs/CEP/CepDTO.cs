using Domain.DTOs.Municipio;

namespace Domain.DTOs.CEP
{
    public class CepDTO
    {
        public Guid Id { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public Guid MunicipioId { get; set; }
        public MunicipioCompletoDTO? Municipio { get; set; }
    }
}
