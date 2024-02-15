using Domain.DTOs.County;
using Domain.DTOs.UF;
using Faker;

namespace Service.Test.County
{
    public class CountyTests
    {
        public static string NameCounty { get; set; } = string.Empty;
        public static int CodeIBGECounty { get; set; }
        public static string NameUpdateCounty { get; set; } = string.Empty;
        public static int CodeIBGEUpdateCounty { get; set; }
        public static Guid IdCounty { get; set; }
        public static Guid IdUF { get; set; }

        public List<CountyDTO> listDTO = new List<CountyDTO>();
        public CountyDTO countyDTO;
        public CountyCompleteDTO countyCompleteDTO;
        public CountyCreateDTO countyCreateDTO;
        public CountyCreateResultDTO countyCreateResultDTO;
        public CountyUpdateDTO countyUpdateDTO;
        public CountyUpdateResultDTO countyUpdateResultDTO;

        public CountyTests()
        {
            IdCounty = Guid.NewGuid();
            NameCounty = Address.StreetName();
            CodeIBGECounty = RandomNumber.Next(1, 10000);
            NameUpdateCounty = Address.StreetName();
            CodeIBGEUpdateCounty = RandomNumber.Next(1, 10000);
            IdUF = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CountyDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = Address.StreetName(),
                    CodeIBGE = RandomNumber.Next(1, 10000),
                    UFId = Guid.NewGuid()
                };
                listDTO.Add(dto);
            }

            countyDTO = new CountyDTO()
            {
                Id = IdCounty,
                Name = NameCounty,
                CodeIBGE = CodeIBGECounty,
                UFId = IdUF,
            };

            countyCompleteDTO = new CountyCompleteDTO()
            {
                Id = IdCounty,
                Name = NameCounty,
                CodeIBGE = CodeIBGECounty,
                UFId = IdUF,
                UF = new UFDTO
                {
                    Id = Guid.NewGuid(),
                    Name = Address.UsState(),
                    Initials = Address.UsState().Substring(1, 3)
                }
            };

            countyCreateDTO = new CountyCreateDTO()
            {
                Name = NameCounty,
                CodeIBGE = CodeIBGECounty,
                UFId = IdUF
            };

            countyCreateResultDTO = new CountyCreateResultDTO()
            {
                Id = IdCounty,
                Name = NameCounty,
                CodeIBGE = CodeIBGECounty,
                UFId = IdUF,
                CreateAt = DateTime.Now
            };

            countyUpdateDTO = new CountyUpdateDTO()
            {
                Id = IdCounty,
                Name = NameUpdateCounty,
                CodeIBGE = CodeIBGEUpdateCounty,
                UFId = IdUF
            };

            countyUpdateResultDTO = new CountyUpdateResultDTO()
            {
                Id = IdCounty,
                Name = NameUpdateCounty,
                CodeIBGE = CodeIBGEUpdateCounty,
                UFId = IdUF,
                UpdateAt = DateTime.Now
            };
        }
    }
}
