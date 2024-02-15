using Domain.DTOs.County;
using Domain.DTOs.UF;
using Domain.DTOs.ZipCode;
using Faker;

namespace Service.Test.ZipCode
{
    public class ZipCodeTests
    {
        public static string ZipCodeOrigin { get; set; } = string.Empty;
        public static string PublicPlaceOrigin { get; set; } = string.Empty;
        public static string NumberOrigin { get; set; } = string.Empty;
        public static string ZipCodeUpdated { get; set; } = string.Empty;
        public static string PublicPlaceUpdated { get; set; } = string.Empty;
        public static string NumberUpdated { get; set; } = string.Empty;
        public static Guid IdCounty { get; set; }
        public static Guid IdZipCode { get; set; }

        public List<ZipCodeDTO> listDTO = new List<ZipCodeDTO>();
        public ZipCodeDTO zipCodeDTO;
        public ZipCodeCreateDTO zipCodeCreateDTO;
        public ZipCodeCreateResultDTO zipCodeCreateResultDTO;
        public ZipCodeUpdateDTO zipCodeUpdateDTO;
        public ZipCodeUpdateResultDTO zipCodeUpdateResultDTO;

        public ZipCodeTests()
        {
            IdCounty = Guid.NewGuid();
            IdZipCode = Guid.NewGuid();
            ZipCodeOrigin = Address.ZipCode();
            NumberOrigin = RandomNumber.Next(1, 10000).ToString();
            PublicPlaceOrigin = Address.StreetName();
            ZipCodeUpdated = Address.ZipCode();
            NumberUpdated = RandomNumber.Next(1, 10000).ToString();
            PublicPlaceUpdated = Address.StreetName();

            for (int i = 0; i < 10; i++)
            {
                var dto = new ZipCodeDTO()
                {
                    Id = Guid.NewGuid(),
                    ZipCode = Address.ZipCode(),
                    PublicPlace = Address.StreetName(),
                    Number = RandomNumber.Next(1, 10000).ToString(),
                    CountyId = Guid.NewGuid(),
                    County = new CountyCompleteDTO
                    {
                        Id = IdCounty,
                        Name = Address.City(),
                        CodeIBGE = RandomNumber.Next(1, 10000),
                        UFId = Guid.NewGuid(),
                        UF = new UFDTO
                        {
                            Id = Guid.NewGuid(),
                            Name = Address.UsState(),
                            Initials = Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listDTO.Add(dto);
            }

            zipCodeDTO = new ZipCodeDTO()
            {
                Id = IdZipCode,
                ZipCode = ZipCodeOrigin,
                PublicPlace = PublicPlaceOrigin,
                Number = NumberOrigin,
                CountyId = IdCounty,
                County = new CountyCompleteDTO
                {
                    Id = IdCounty,
                    Name = Address.City(),
                    CodeIBGE = RandomNumber.Next(1, 10000),
                    UFId = Guid.NewGuid(),
                    UF = new UFDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = Address.UsState(),
                        Initials = Address.UsState().Substring(1, 3)
                    }
                }
            };

            zipCodeCreateDTO = new ZipCodeCreateDTO()
            {
                ZipCode = ZipCodeOrigin,
                PublicPlace = PublicPlaceOrigin,
                Number = NumberOrigin,
                CountyId = IdCounty
            };

            zipCodeCreateResultDTO = new ZipCodeCreateResultDTO()
            {
                Id = IdZipCode,
                ZipCode = ZipCodeOrigin,
                PublicPlace = PublicPlaceOrigin,
                Number = NumberOrigin,
                CountyId = IdCounty,
                CreateAt = DateTime.Now
            };

            zipCodeUpdateDTO = new ZipCodeUpdateDTO()
            {
                Id = IdZipCode,
                ZipCode = ZipCodeUpdated,
                PublicPlace = PublicPlaceUpdated,
                Number = NumberUpdated,
                CountyId = IdCounty,
            };

            zipCodeUpdateResultDTO = new ZipCodeUpdateResultDTO()
            {
                Id = IdZipCode,
                ZipCode = ZipCodeUpdated,
                PublicPlace = PublicPlaceUpdated,
                Number = NumberUpdated,
                CountyId = IdCounty,
                UpdateAt = DateTime.Now
            };
        }
    }
}
