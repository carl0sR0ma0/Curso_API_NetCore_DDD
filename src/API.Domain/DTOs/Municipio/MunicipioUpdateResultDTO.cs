namespace Domain.DTOs.Municipio
{
    public class MunicipioUpdateResultDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CodeIBGE { get; set; }
        public Guid UFId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
