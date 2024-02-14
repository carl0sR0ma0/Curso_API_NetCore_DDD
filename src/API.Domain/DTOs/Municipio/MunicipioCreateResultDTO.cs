namespace Domain.DTOs.Municipio
{
    public class MunicipioCreateResultDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CodeIBGE { get; set; }
        public Guid UFId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
