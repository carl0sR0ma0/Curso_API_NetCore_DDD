using Domain.DTOs.UF;
using Faker;

namespace Service.Test.UF
{
    public class UFTests
    {
        public static string Name { get; set; } = string.Empty;
        public static string Initial { get; set; } = string.Empty;
        public static Guid IDUF { get; set; }

        public List<UFDTO> listUFDTO = new List<UFDTO>();
        public UFDTO UFDTO { get; set; }

        public UFTests()
        {
            IDUF = Guid.NewGuid();
            Initial = Address.UsState().Substring(1, 3);
            Name = Address.UsState();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UFDTO()
                {
                    Id = Guid.NewGuid(),
                    Initials = Address.UsState().Substring(1, 3),
                    Name = Address.UsState()
                };
                listUFDTO.Add(dto);
            }

            UFDTO = new UFDTO()
            {
                Id = IDUF,
                Initials = Initial,
                Name = Name
            };
        }
    }
}
