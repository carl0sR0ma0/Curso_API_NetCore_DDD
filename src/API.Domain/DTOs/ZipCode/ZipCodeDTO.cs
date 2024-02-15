using Domain.DTOs.County;

namespace Domain.DTOs.ZipCode
{
    public class ZipCodeDTO
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string PublicPlace { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public Guid CountyId { get; set; }
        public CountyCompleteDTO? County { get; set; }
    }
}
