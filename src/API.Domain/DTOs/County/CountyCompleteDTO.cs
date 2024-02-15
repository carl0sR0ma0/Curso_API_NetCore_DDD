using Domain.DTOs.UF;

namespace Domain.DTOs.County
{
    public class CountyCompleteDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CodeIBGE { get; set; }
        public Guid UFId { get; set; }
        public UFDTO? UF { get; set; }
    }
}
