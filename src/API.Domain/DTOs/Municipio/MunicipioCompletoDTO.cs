using Domain.DTOs.UF;

namespace Domain.DTOs.Municipio
{
    public class MunicipioCompletoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CodeIBGE { get; set; }
        public Guid UFId { get; set; }
        public UFDTO? UF { get; set; }
    }
}
