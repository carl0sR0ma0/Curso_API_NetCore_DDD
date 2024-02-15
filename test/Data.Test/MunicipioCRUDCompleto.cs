using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Faker;

namespace Data.Test
{
    public class MunicipioCRUDCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public MunicipioCRUDCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Município")]
        [Trait("CRUD", "CountyEntity")]
        public async Task ShouldCRUDCounty()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                CountyImplementation _repository = new CountyImplementation(context);
                CountyEntity _entity = new CountyEntity
                {
                    Name = Address.City(),
                    CodeIBGE = RandomNumber.Next(1000000, 9999999),
                    UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _registroCriado = await _repository.InsertAsync(_entity);
            }
        }
    }
}
