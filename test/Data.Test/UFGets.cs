using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test
{
    public class UFGets : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UFGets(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "GET das UFs")]
        [Trait("GETs", "UFEntity")]
        public async Task ShouldGetUFs()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UFImplementation _repository = new UFImplementation(context);

                UFEntity _entity = new UFEntity()
                {
                    Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                    Initials = "SP",
                    Name = "São Paulo"
                };

                var _existRegister = await _repository.ExistAsync(_entity.Id);
                Assert.True(_existRegister);

                var _registerSelected = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(_registerSelected);
                Assert.Equal(_entity.Initials, _registerSelected.Initials);
                Assert.Equal(_entity.Name, _registerSelected.Name);
                Assert.Equal(_entity.Id, _registerSelected.Id);

                var _allRegisters = await _repository.SelectAsync();
                Assert.NotNull(_allRegisters);
                Assert.True(_allRegisters.Count() == 27);
            }
        }
    }
}
